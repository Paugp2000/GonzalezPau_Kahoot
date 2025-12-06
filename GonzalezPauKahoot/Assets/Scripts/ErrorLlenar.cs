using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ErrorLlenar : MonoBehaviour
{
    public TextMeshProUGUI textError;

    private void Start()
    {
        llenarTextoError();
    }
    public void llenarTextoError()
    {
        textError.text = ErrorSelector.errorFileLoaded;
    }
    public void volverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
