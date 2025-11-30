using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XMLWriter : MonoBehaviour
{
    
    public Kahoot kahootActual;
    string targetFolderPath;
    public string targetFilePath;
    public MenuPrincipalController menu;
    public KahootGameController gameController;

    private void Awake()
    {
        targetFolderPath = Application.persistentDataPath + "/XML";
        if (!Directory.Exists(targetFolderPath))
        {
            Directory.CreateDirectory(targetFolderPath);
        }
       
    }
    private void Start()
    {
        setKahootActual(KahootSelector.LoadKahoot(KahootSelector.kahootFileLoaded));
        string targetName = kahootActual.Title;
        targetFilePath = Application.persistentDataPath + "/XML/" + targetName + ".xml";
        XMLCreator();
    }
    public void setKahootActual(Kahoot akahoot)
    {
        kahootActual = akahoot;
    }
    public Kahoot getKahootActual()
    {
        return kahootActual;
    }
    public void XMLCreator()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(targetFilePath);
        XmlElement root = xmlDoc.CreateElement("Kahoot");
        xmlDoc.AppendChild(root);
        XmlElement kahootName = xmlDoc.CreateElement("kahootName");
        kahootName.InnerText = kahootActual.Title;
        root.AppendChild(kahootName);
        XmlElement playerName = xmlDoc.CreateElement ("name");
        playerName.InnerText = menu.getNombrePlayer();
        root.AppendChild(playerName);
        XmlElement puntuacion = xmlDoc.CreateElement("puntuacion");
        puntuacion.InnerText = gameController.getPuntuacion().ToString();
        root.AppendChild(puntuacion);
        xmlDoc.Save(targetFilePath);
        
    }
}
