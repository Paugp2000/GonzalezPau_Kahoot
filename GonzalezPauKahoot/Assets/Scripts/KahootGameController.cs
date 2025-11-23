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
    public TextMeshProUGUI timerText;

    private void Start()
    {
        kahootActual = kahootSelector.kahootSelect;
    }
    private void Update()
    {
        QuestionTimer(timeLimit);
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
}
