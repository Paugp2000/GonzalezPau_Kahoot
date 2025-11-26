using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XMLWriter : MonoBehaviour
{
    string nameKahoot;
    string targetPath = Application.streamingAssetsPath + "XML";

    private void Awake()
    {
        if (!Directory.Exists(targetPath))
        {
            Directory.CreateDirectory(targetPath);
        }
        
    }
    public void XMLAddPlayer(string playerName)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(targetPath);
    }
}
