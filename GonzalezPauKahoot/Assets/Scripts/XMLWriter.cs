using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XMLWriter : MonoBehaviour
{
    
    public Kahoot kahootActual;
    string targetPath = Application.streamingAssetsPath + "/XML";
    string targetNamePath;
    public MenuPrincipalController menu;
    public KahootGameController gameController;

    private void Awake()
    {
        if (!Directory.Exists(targetPath))
        {
            Directory.CreateDirectory(targetPath);
        }
        string targetName = kahootActual.Title;
        targetNamePath = Application.streamingAssetsPath + "/XML/" + targetName+ "*.xml";
    }
    private void Start()
    {
        XMLCreator();
    }
    public void XMLCreator()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(targetPath);
        XmlElement root = xmlDoc.CreateElement("Kahoot");
        xmlDoc.AppendChild(root);
        XmlElement kahootName = xmlDoc.CreateElement("kahootName");
        kahootName.InnerText = kahootActual.Title;
        xmlDoc.AppendChild(kahootName);
        XmlElement playerName = xmlDoc.CreateElement ("name");
        playerName.InnerText = menu.getNombrePlayer();
        root.AppendChild(playerName);
        XmlElement puntuacion = xmlDoc.CreateElement("puntuacion");
        puntuacion.InnerText = gameController.getPuntuacion().ToString();
        root.AppendChild(puntuacion);
        xmlDoc.Save(targetNamePath);    
    }
}
