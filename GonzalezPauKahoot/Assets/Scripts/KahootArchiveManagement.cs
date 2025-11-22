using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KahootArchiveManagement : MonoBehaviour
{
    string sourcePath;
    string targetPath;
    void Awake()
    {
        sourcePath = Path.Combine(Application.streamingAssetsPath, "JSON_data");
        targetPath = Path.Combine(Application.persistentDataPath, "Kahoots");

        if (!Directory.Exists(targetPath))
        {
            Directory.CreateDirectory(targetPath);
        }

        // Copiar tots els JSON
        string[] files = Directory.GetFiles(sourcePath, "*.json");
        foreach (string file in files)
        {
            string fileName = Path.GetFileName(file);
            string destFile = Path.Combine(targetPath, fileName);

            if (!File.Exists(destFile))
            {
                File.Copy(file, destFile);
                Debug.Log("Copiat: " + fileName);
            }
        }
    }
}
