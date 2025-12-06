using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
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
        try
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
                else if (node.Name == "player")
                {
                    string nombre = "";
                    int puntos = 0;

                    foreach (XmlNode child in node.ChildNodes)
                    {
                        if (child.Name == "name") nombre = child.InnerText;
                        if (child.Name == "puntuacion") puntos = int.Parse(child.InnerText);
                    }

                    puntuacion.PlayerName.Add(nombre);
                    puntuacion.puntuacionPlayer.Add(puntos);
                }
            }
        }
        catch (Exception ex)
        {
            HandleXmlError(ex, path);
            MostrarLeaderboardBuida();
        }
        
    }
    public void omplePuntuacions()
    {
        kahootEscogido.text = puntuacion.KahootName.ToString();
        for(int i = 0; i<puntuacion.puntuacionPlayer.Count; i++)
        {
            GameObject text = Instantiate(textPrefab, contentPanel);
            text.GetComponent<TextMeshProUGUI>().text = puntuacion.PlayerName[i] + " : " + puntuacion.puntuacionPlayer[i];
        }
        
    }
    void HandleXmlError(Exception ex, string filePath)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        string logFileName = $"ErrorXML_{timestamp}.txt";
        string logPath = Path.Combine(Application.persistentDataPath, "ErrorLogs", logFileName);

        Directory.CreateDirectory(Path.GetDirectoryName(logPath));

        string content = $"Fitxer: {filePath}\nError: {ex.GetType().Name}\nMissatge: {ex.Message}\nData: {DateTime.Now}\nComentari: Error en la lectura del fitxer XML. Comprova si el format és correcte o si el fitxer està corrupte.";
        File.WriteAllText(logPath, content);
    }
    void MostrarLeaderboardBuida()
    {
        kahootEscogido.text = "Error";
    }
}
