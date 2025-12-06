using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KahootGameController : MonoBehaviour
{
    public Kahoot kahootActual;
    public KahootSelector kahootSelector;
    public string filePath;
    public float timeLimit;
    private float timeLeft;
    public TextMeshProUGUI textPregunta;
    public TextMeshProUGUI textResposta1;
    public TextMeshProUGUI textResposta2;
    public TextMeshProUGUI textResposta3;
    public TextMeshProUGUI textResposta4;
    public TextMeshProUGUI textExplicacio;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI puntuacionText;
    public Button Resposta1;
    public Button Resposta2;
    public Button Resposta3;
    public Button Resposta4;
    private int numeroPregunta = 0;
    private bool respuestaValida = false;
    public static int puntuacion;
    private int opcio = -1;

    private void Start()
    {
        if (KahootSelector.LoadKahoot(KahootSelector.kahootFileLoaded) == null)
        {
            SceneManager.LoadScene("MenuErrores");
        }
        else
        {
            timeLimit = 20;
            SetSelectedKahoot(KahootSelector.LoadKahoot(KahootSelector.kahootFileLoaded));
            introducirDatosKahoot(kahootActual);
            timeLeft = timeLimit;
        }
       
    }
    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeLeft).ToString();
        }
        else
        {
            timeLeft = 0;
            passarSiguientePregunta();
        }

        if (numeroPregunta == kahootActual.Quiz.Length)
        {
            SceneManager.LoadScene(2);
        }
        Debug.Log(opcio);
    }

    public void SetSelectedKahoot(Kahoot aKahoot)
    {
        kahootActual = aKahoot;
    }

    public void introducirDatosKahoot(Kahoot aKahoot)
    {
        textPregunta.text = aKahoot.Quiz[numeroPregunta].question.ToString();
        textResposta1.text = aKahoot.Quiz[numeroPregunta].options[0].ToString();
        textResposta2.text = aKahoot.Quiz[numeroPregunta].options[1].ToString();
        textResposta3.text = aKahoot.Quiz[numeroPregunta].options[2].ToString();
        textResposta4.text = aKahoot.Quiz[numeroPregunta].options[3].ToString();
        textExplicacio.text = aKahoot.Quiz[numeroPregunta].explanation.ToString();
        puntuacionText.text = puntuacion.ToString();
        
    }
    public void comprovarRespuesta(Button button)
    {
        
        if (button.tag == "First")
        {
            opcio = 0;
        }else if (button.tag == "Second")
        {
            opcio = 1;
        }else if (button.tag == "Third")
        {
            opcio = 2;
        }else if (button.tag == "Fourth")
        {
            opcio = 3;
        }
        else
        {
            opcio = -1;
        }
        
        if (kahootActual.Quiz[numeroPregunta].answer == opcio)
        {
            respuestaValida = true;
        }
        else
        {
            respuestaValida= false; 
        }
        assignarPuntos(respuestaValida);
    }
    public void assignarPuntos(bool respuesta)
    {
        if(respuesta == true)
        {
            puntuacion += 10;
        }else if(respuesta == false)
        {
            if(puntuacion < 5)
            {
                puntuacion -= 0;
            }
            else
            {
                puntuacion -= 5;
            }
        }
        passarSiguientePregunta();
    }
    public void passarSiguientePregunta()
    {
        if (numeroPregunta < kahootActual.Quiz.Length+1)
        {
            ++numeroPregunta;
            timeLeft = timeLimit;
            if (numeroPregunta < 5)
            {
                introducirDatosKahoot(kahootActual);
            }
        }
        
    }
    public int getPuntuacion()
    {
        return puntuacion;
    }
}
