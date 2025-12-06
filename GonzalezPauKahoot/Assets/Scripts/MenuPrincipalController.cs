using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour
{
    int indiceDeEscena = 0;
    public TMP_InputField colocarNombre;
    public static string nombrePlayer;

    public static MenuPrincipalController Instance;
    private void Awake()
    {
        if (Instance == null){
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    
    public void trasladarASeleccionDeKahoot()
    {
        //Sacar valor del input field e introducirlo en nombrePLayer
        nombrePlayer = colocarNombre.textComponent.text;
        indiceDeEscena = 3;
        SceneManager.LoadScene(indiceDeEscena);
        
    }
    public void trasladarAPantallaDePuntuaciones()
    {
        SceneManager.LoadScene("ConsultorDePuntuaciones");
       
    }
    public void trasladarASobreMi()
    {
        indiceDeEscena = 4;
        SceneManager.LoadScene(indiceDeEscena);
    }
    public void trasladarARegistroErrores()
    {
        indiceDeEscena = 1;
        SceneManager.LoadScene(indiceDeEscena);
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void seleccionarNombrePlayer()
    {
        colocarNombre.gameObject.SetActive(true);
    }
    public string getNombrePlayer()
    {
        return nombrePlayer.ToString();
    }
}
