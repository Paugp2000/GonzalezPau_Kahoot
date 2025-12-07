using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KahootCreatorAdmin : MonoBehaviour
{
    public GameObject canvasInicio;
    public GameObject canvasPreguntas;
    public GameObject canvasFinal;
    public TMP_InputField nombreKahoot;
    public TMP_Dropdown numPreguntas;

    public TMP_InputField Enunciado;
    public TMP_InputField Respuesta1;
    public TMP_InputField Respuesta2;
    public TMP_InputField Respuesta3;
    public TMP_InputField Respuesta4;
    public TMP_Dropdown resCorrecta;
    public TMP_Dropdown Tiempo;

    public string nombreKahootText;
    public int numPreguntasValue;

    public string enunciadoText;
    public string respuesta1;
    public string respuesta2;
    public string respuesta3;
    public string respuesta4;
    public int rescorrecta;
    public int tiempo;

    public int contadorPreguntas = 0;
    public Kahoot nuevoKahoot;
    public string json;


    private void Start()
    {
        canvasInicio.SetActive(true);
        canvasPreguntas.SetActive(false);
        canvasFinal.SetActive(false);
    }

    void DropdownValueChanged(TMP_Dropdown change)
    {
        string valorTexto = change.options[change.value].text;
        numPreguntasValue = int.Parse(valorTexto);
        Debug.Log("Número de preguntas elegido: " + numPreguntasValue);
    }

    public void guardarDatosCanvasInicio()
    {
        nombreKahootText = nombreKahoot.text; // CORREGIDO
        DropdownValueChanged(numPreguntas);
        PonerNombreAlKahoot();
        canvasInicio.SetActive(false);
        canvasFinal.SetActive(false);
        canvasPreguntas.SetActive(true);
    }

    public void guardarDatosPreguntas()
    {
        enunciadoText = Enunciado.text;   // CORREGIDO
        respuesta1 = Respuesta1.text;
        respuesta2 = Respuesta2.text;
        respuesta3 = Respuesta3.text;
        respuesta4 = Respuesta4.text;
        RespuestaCorrecta(resCorrecta);
        TiempoCorrecto(Tiempo);
        AñadirPreguntaAlKahoot(nuevoKahoot);
    }

    void RespuestaCorrecta(TMP_Dropdown change)
    {
        // Si las opciones son números, parseamos. Si no, usamos el índice.
        if (int.TryParse(change.options[change.value].text, out int result))
            rescorrecta = result;
        else
            rescorrecta = change.value + 1;
    }

    void TiempoCorrecto(TMP_Dropdown change)
    {
        tiempo = int.Parse(change.options[change.value].text);
    }

    public void PonerNombreAlKahoot()
    {
        nuevoKahoot = new Kahoot();
        nuevoKahoot.Quiz =  new List<Question>();
        nuevoKahoot.Title = nombreKahootText;
    }

    public void AñadirPreguntaAlKahoot(Kahoot nuevoKahoot)
    {
        // Creamos la pregunta en el momento y la añadimos
        Question nuevaPregunta = new Question();
        nuevaPregunta.question = enunciadoText;
        nuevaPregunta.options[0] = respuesta1;
        nuevaPregunta.options[1] = respuesta2;
        nuevaPregunta.options[2] = respuesta3;
        nuevaPregunta.options[3] = respuesta4;
        nuevaPregunta.answer = rescorrecta - 1;
        nuevaPregunta.tiempo = tiempo;

        nuevoKahoot.Quiz.Add(nuevaPregunta);
        contadorPreguntas++;

        if (numPreguntasValue == contadorPreguntas)
        {
            TransformarEnJson();
            ColocarJSON();
            MostrarMenuFinal();
        }
    }

    public void TransformarEnJson()
    {
        json = JsonUtility.ToJson(nuevoKahoot, true); 
    }

    public void ColocarJSON()
    {
        string carpeta = Path.Combine(Application.persistentDataPath, "Kahoots");
        if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

        string ruta = Path.Combine(carpeta, nombreKahootText + ".json");
        File.WriteAllText(ruta, json);

        Debug.Log("Archivo JSON guardado en: " + ruta);
    }

    public void MostrarMenuFinal()
    {
        canvasPreguntas.SetActive(false);
        canvasFinal.SetActive(true);
    }

    public void volverAlMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
