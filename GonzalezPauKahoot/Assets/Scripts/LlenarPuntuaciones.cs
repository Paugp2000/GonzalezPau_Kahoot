using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LlenarPuntuaciones : MonoBehaviour
{
    private Puntuaciones puntuacionAMostrar;
    public Transform contentPanel;
    public GameObject textPrefab;
    public TextMeshProUGUI kahootEscogido;

    private void Start()
    {
        setPuntacionAMostrar(ScoreSelector.LoadPuntuacion(ScoreSelector.finalFilePath));
        omplePuntuacions();

    }
    public void setPuntacionAMostrar(Puntuaciones puntuacionA)
    {
        puntuacionAMostrar = puntuacionA;
    }
    public void omplePuntuacions()
    {
        kahootEscogido.text = puntuacionAMostrar.KahootName.ToString();
        for (int i = 0; i < puntuacionAMostrar.puntuacionPlayer.Count; i++)
        {
            GameObject text = Instantiate(textPrefab, contentPanel);
            text.GetComponent<TextMeshProUGUI>().text = puntuacionAMostrar.PlayerName[i] + " : " + puntuacionAMostrar.puntuacionPlayer[i];
        }

    }
    public void volverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
