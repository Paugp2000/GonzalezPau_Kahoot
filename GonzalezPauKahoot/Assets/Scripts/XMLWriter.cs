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
    public KahootGameController gameController;
    public XMLReader reader;    

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
        if (!File.Exists(targetFilePath)) {
            using FileStream stream = File.Create(targetFilePath);
            stream.Close();
            XMLCreator();
        }
        else
        {
            XMLAdder();
        }
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

        // Crear nodo raíz <kahoot>
        XmlElement root = xmlDoc.CreateElement("kahoot");
        xmlDoc.AppendChild(root);

        // Añadir <kahootName>
        XmlElement kahootName = xmlDoc.CreateElement("kahootName");
        kahootName.InnerText = kahootActual.Title;
        root.AppendChild(kahootName);

        // Crear nodo <player>
        XmlElement player = xmlDoc.CreateElement("player");

        // Añadir <name> dentro de <player>
        XmlElement playerName = xmlDoc.CreateElement("name");
        playerName.InnerText = MenuPrincipalController.Instance.getNombrePlayer();
        player.AppendChild(playerName);

        // Añadir <puntuacion> dentro de <player>
        XmlElement puntuacion = xmlDoc.CreateElement("puntuacion");
        puntuacion.InnerText = gameController.getPuntuacion().ToString();
        player.AppendChild(puntuacion);

        // Finalmente añadir <player> al root
        root.AppendChild(player);

        // Guardar archivo
        xmlDoc.Save(targetFilePath);
    }
    public void XMLAdder()
    {
        // Cargar el XML existente
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(targetFilePath);

        // Obtener el nodo raíz <kahoot>
        XmlNode root = xmlDoc.DocumentElement;

        // Crear nuevo nodo <player>
        XmlElement player = xmlDoc.CreateElement("player");

        // Crear <name>
        XmlElement playerName = xmlDoc.CreateElement("name");
        playerName.InnerText = MenuPrincipalController.Instance.getNombrePlayer();
        player.AppendChild(playerName);

        // Crear <puntuacion>
        XmlElement puntuacion = xmlDoc.CreateElement("puntuacion");
        puntuacion.InnerText = gameController.getPuntuacion().ToString();
        player.AppendChild(puntuacion);

        // Añadir <player> al root
        root.AppendChild(player);

        // Guardar cambios en el archivo
        xmlDoc.Save(targetFilePath);
    }
}
