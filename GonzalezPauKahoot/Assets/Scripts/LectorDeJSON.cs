using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Windows;

public class LectorDeJSON : MonoBehaviour
{
    string jsonDataPath;
    private void Awake()
    {
        Directory.CreateDirectory(Application.persistentDataPath + "/JSON");
    }
    private void Start()
    {
        jsonDataPath = Application.persistentDataPath + "/JSON";
        Debug.Log(jsonDataPath);
    }
}
