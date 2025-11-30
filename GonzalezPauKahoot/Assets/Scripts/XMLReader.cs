using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class XMLReader : MonoBehaviour
{
    public XMLWriter writer;
    public Kahoot kahootActual;
    public Transform contentPanel;
    public string targetPath;
    public List <Puntuaciones> puntuacionTotal;
    public Puntuaciones puntuacion;
    public GameObject textPrefab;

    public void Start()
    {
        puntuacionTotal = new List<Puntuaciones>();
        targetPath = writer.targetFilePath;
        readXML(targetPath);
        
    }
    public void getKahootActual()
    {
        kahootActual = writer.getKahootActual();
    }
    public void readXML(string path)
    {
        puntuacion = new Puntuaciones();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(path);
        XmlNode root = xmlDoc.DocumentElement;
        foreach (XmlNode node in root.ChildNodes)
        {
            if (node.Name == "kahootName")
            {
                puntuacion.KahootName = node.InnerText;
            }
            if (node.Name == "name")
            {
                puntuacion.PlayerName = node.InnerText; 
            }
            if (node.Name == "puntuacion")
            {
                puntuacion.puntuacionPlayer = int.Parse(node.InnerText);
            }
        }
        puntuacionTotal.Add(puntuacion);
    }
    public void omplePuntuacions()
    {
        foreach(Puntuaciones puntuacion in puntuacionTotal) 
        {
            GameObject text = Instantiate(textPrefab, contentPanel);
            text.GetComponent<TextMeshProUGUI>().text = puntuacion.PlayerName + " : " + puntuacion.puntuacionPlayer;
        }
    }
}
