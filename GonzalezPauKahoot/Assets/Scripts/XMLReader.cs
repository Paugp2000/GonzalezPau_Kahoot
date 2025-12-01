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
    public TextMeshProUGUI kahootEscogido;
    public int contador = 0;

    public void Start()
    {
        puntuacionTotal = new List<Puntuaciones>();
        targetPath = writer.targetFilePath;
        readXML(targetPath);
        omplePuntuacions();
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
                puntuacion.PlayerName[contador] = node.InnerText; 
            }
            if (node.Name == "puntuacion")
            {
                puntuacion.puntuacionPlayer[contador] = int.Parse(node.InnerText);
            }
        }
        contador++;
    }
    public void omplePuntuacions()
    {
        kahootEscogido.text = puntuacion.KahootName.ToString();
        for(int i = 0; i<puntuacion.puntuacionPlayer.Length; i++)
        {
            GameObject text = Instantiate(textPrefab, contentPanel);
            text.GetComponent<TextMeshProUGUI>().text = puntuacion.PlayerName[i] + " : " + puntuacion.puntuacionPlayer[i];
        }
        
    }
}
