using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KahootSelector : MonoBehaviour
{
    public Transform contentPanel; // Assigna el Content del ScrollView
    public GameObject kahootButtonPrefab; // Prefab del botó
    public static string kahootFileLoaded;

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
                kahootFileLoaded = file;
                SceneManager.LoadScene(5);
            });
        }
    }

    void SelectKahoot(string filePath)
    {
        Debug.Log("Kahoot seleccionat: " + filePath);
    }

    public static Kahoot LoadKahoot(string filePath)
    {
        string json = File.ReadAllText(filePath);
        Kahoot kahoot = JsonUtility.FromJson<Kahoot>(json);
        return kahoot;
    }
}
