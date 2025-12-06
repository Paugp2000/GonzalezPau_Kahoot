using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class XMLDataManager : MonoBehaviour
{
    string sourcePath;
    string targetPath;
    
    void Awake()
    {
        sourcePath = Path.Combine(Application.persistentDataPath, "XML");
        targetPath = Path.Combine(Application.streamingAssetsPath, "XML");

        if (!Directory.Exists(targetPath))
        {
            Directory.CreateDirectory(targetPath);
        }

      
        string[] files = Directory.GetFiles(sourcePath, "*.xml");
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(targetPath, fileName);
           

            if (!File.Exists(destFile))
            {
                File.Copy(file, destFile);
                Debug.Log("Copiat: " + fileName);
            }
            else if (File.Exists(destFile))
            {
                 
            }
        }
    }
    public void volverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}

