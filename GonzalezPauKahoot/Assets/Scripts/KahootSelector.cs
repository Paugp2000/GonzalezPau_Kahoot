using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KahootSelector : MonoBehaviour
{
    public Transform contentPanel; // Assigna el Content del ScrollView
    public GameObject kahootButtonPrefab; // Prefab del botó

    void Start()
    {
        LoadKahoots();
    }

    void LoadKahoots()
    {
        string path = Path.Combine(Application.persistentDataPath, "Kahoots");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        string[] files = Directory.GetFiles(path, "*.json");

        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);

            GameObject newButton = Instantiate(kahootButtonPrefab, contentPanel);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = fileName;

            newButton.GetComponent<Button>().onClick.AddListener(() => {
                SelectKahoot(file);
            });
        }
    }

    void SelectKahoot(string filePath)
    {
        Debug.Log("Kahoot seleccionat: " + filePath);
        // Aquí pots carregar el JSON i passar a l’escena de joc
    }
}
