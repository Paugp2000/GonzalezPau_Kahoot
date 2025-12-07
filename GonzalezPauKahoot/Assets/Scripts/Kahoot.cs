using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Kahoot
{
    public string Title;       // Nom del kahoot
    public string Type;        // Tipus (quiz, examen, etc.)
    public List <Question> Quiz; // Llista de preguntes
}

[Serializable]
public class Question
{
    public string type;        // Tipus de pregunta (singleSelect, multiSelect...)
    public string question;    // Text de la pregunta
    public string[] options;   // Opcions de resposta
    public int answer;       // Índex de la resposta correcta (pot ser més d’una)
    public string explanation; // Explicació de la resposta
    public int tiempo; // Temps de la pregunta
}