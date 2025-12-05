using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSelector : MonoBehaviour
{
    public Transform contentPanel;
    public GameObject scoreButtonPrefab;
    public static Puntuaciones puntuacion;
    public string fileName2;
    public static string finalFilePath;

    private void Start()
    {
        loadOptionsScores();
    }
    public void loadOptionsScores()
    {
        // Build and ensure the directory exists
        string path2 = Path.Combine(Application.persistentDataPath, "XML");
        if (!Directory.Exists(path2)) Directory.CreateDirectory(path2);

        // Get all XML files
        string[] files = Directory.GetFiles(path2, "*.xml");

        foreach (string file in files)
        {
            // Capture per-iteration locals to avoid closure pitfalls
            string fileNameNoExt = Path.GetFileNameWithoutExtension(file);
            string filePathFull = Path.Combine(path2, fileNameNoExt + ".xml");

            // Create button
            GameObject newButton = Instantiate(scoreButtonPrefab, contentPanel);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = fileNameNoExt;

            // Assign listener using the captured locals
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                puntuacion = LoadPuntuacion(filePathFull);
                finalFilePath = filePathFull;
                SceneManager.LoadScene("ResultadosPuntuaciones");
            });
        }
    }
    public static Puntuaciones LoadPuntuacion(string filePath)
    {
        puntuacion = new Puntuaciones();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(filePath);
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
        return puntuacion;
    }
}


