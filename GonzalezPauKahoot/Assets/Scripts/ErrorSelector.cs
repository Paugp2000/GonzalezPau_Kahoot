using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ErrorSelector : MonoBehaviour
{
    public Transform contentPanel; // Assigna el Content del ScrollView
    public GameObject errorButtonPrefab; // Prefab del botó
    public static string errorFileLoaded;

    private void Start()
    {
        LoadError();
    }

    public void LoadError()
    {
        string path = Path.Combine(Application.persistentDataPath, "ErrorLogs");
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        string[] files = Directory.GetFiles(path, "*.txt");

        foreach (string file in files)
        {
            string fileName = Path.GetFileNameWithoutExtension(file);

            GameObject newButton = Instantiate(errorButtonPrefab, contentPanel);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = fileName;

            newButton.GetComponent<Button>().onClick.AddListener(() => {
                SceneManager.LoadScene("ErrorMostrar");
                errorFileLoaded = File.ReadAllText(file);
            });
        }
    }
    public void volverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
