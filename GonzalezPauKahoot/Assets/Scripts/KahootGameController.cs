using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KahootGameController : MonoBehaviour
{
    public Kahoot kahootActual;
    public KahootSelector kahootSelector;
    public string filePath;
    public float timeLimit;
    public TextMeshProUGUI textPregunta;
    public TextMeshProUGUI textResposta1;
    public TextMeshProUGUI textResposta2;
    public TextMeshProUGUI textResposta3;
    public TextMeshProUGUI textResposta4;
    public TextMeshProUGUI textExplicacio;
    public TextMeshProUGUI timerText;
    private int numeroPregunta = 0;

    private void Start()
    {
        SetSelectedKahoot(KahootSelector.LoadKahoot(KahootSelector.kahootFileLoaded));
    }
    private void Update()
    {
        QuestionTimer(timeLimit);
        introducirDatosKahoot(kahootActual);
    }
    IEnumerator QuestionTimer(float timeLimit)
    {
        float time = timeLimit;
        while (time > 0)
        {
            time -= Time.deltaTime;
            timerText.text = Mathf.Ceil(time).ToString();
            yield return null;
        }
        
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
    }
}
