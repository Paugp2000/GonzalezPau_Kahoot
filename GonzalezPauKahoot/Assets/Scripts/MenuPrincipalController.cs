using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalController : MonoBehaviour
{
    int indiceDeEscena = 0;
    public void trasladarASeleccionDeKahoot()
    {
        indiceDeEscena = 3;
        SceneManager.LoadScene(indiceDeEscena);
    }
    public void trasladarAPantallaDePuntuaciones()
    {
        indiceDeEscena = 2;
        SceneManager.LoadScene(indiceDeEscena);
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
}
