using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KahootCreatorAdmin : MonoBehaviour
{
    public GameObject canvasInicio;
    public GameObject canvasPreguntas;
    public GameObject canvasFinal;
    public InputField nombreKahoot;
    public Dropdown numPreguntas;

    public InputField Enunciado;
    public InputField Respuesta1;
    public InputField Respuesta2;
    public InputField Respuesta3;
    public InputField Respuesta4;
    public Dropdown resCorrecta;
    public Dropdown Tiempo;

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

    private void Start()
    {
        canvasInicio.SetActive(true);
        canvasPreguntas.SetActive(false);
        canvasFinal.SetActive(false);
    }
    void DropdownValueChanged(Dropdown change)
    {
        // Guardar el valor seleccionado (texto del dropdown)
        string valorTexto = change.options[change.value].text;

        // Convertir a número
        numPreguntasValue = int.Parse(valorTexto);

        Debug.Log("Número de preguntas elegido: " + numPreguntasValue);
    }
    public void guardarDatosCanvasInicio()
    {
        nombreKahootText = nombreKahoot.textComponent.text;
        DropdownValueChanged(numPreguntas);
        PonerNombreAlKahoot();
        canvasInicio.SetActive(false);
        canvasFinal.SetActive(false);
        canvasPreguntas.SetActive(true);
           
    }
    public void guardarDatosPreguntas()
    {
        enunciadoText = Enunciado.textComponent.text;   
        respuesta1 = Respuesta1.textComponent.text;
        respuesta2 = Respuesta2.textComponent.text;
        respuesta3 = Respuesta3.textComponent.text;
        respuesta4 = Respuesta4.textComponent.text;
        RespuestaCorrecta(resCorrecta);
        TiempoCorrecto(Tiempo);
        AñadirPreguntaAlKahoot();
    }
    void RespuestaCorrecta(Dropdown change) 
    {
        rescorrecta = int.Parse(change.options[change.value].text);
    }
    void TiempoCorrecto(Dropdown change)
    {
        tiempo = int.Parse(change.options[change.value].text);
    }

    public void PonerNombreAlKahoot()
    {
        nuevoKahoot = new Kahoot();
        nuevoKahoot.Title = nombreKahootText;
    }
    public void AñadirPreguntaAlKahoot()
    {
        nuevoKahoot.Quiz[contadorPreguntas].question = enunciadoText;
        nuevoKahoot.Quiz[contadorPreguntas].options[0] = respuesta1;
        nuevoKahoot.Quiz[contadorPreguntas].options[1] = respuesta2;
        nuevoKahoot.Quiz[contadorPreguntas].options[2] = respuesta3;
        nuevoKahoot.Quiz[contadorPreguntas].options[3] = respuesta4;
        nuevoKahoot.Quiz[contadorPreguntas].answer = rescorrecta - 1;
        nuevoKahoot.Quiz[contadorPreguntas].tiempo = tiempo;
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

    }
    public void ColocarJSON()
    {

    }
    public void MostrarMenuFinal()
    {

    }
}
