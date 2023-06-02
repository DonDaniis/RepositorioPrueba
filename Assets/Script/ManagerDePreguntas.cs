using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class ManagerDePreguntas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI puntaje;

    [SerializeField] TextMeshProUGUI valorJugadorA;
    [SerializeField] TextMeshProUGUI valorJugadorB;
    [SerializeField] TextMeshProUGUI valorResultado;
    [SerializeField] TextMeshProUGUI frasePuntuacion;
    [Space(10)]

    [SerializeField] TextMeshProUGUI alternativas;
    [Space(10)]
    [SerializeField] PreguntasMatematicas[] preguntas;
   

    int puntajeJugador;
    int puntajePorPregunta = 1;

    int cantidadDePreguntas;
    int preguntasMaximas = 11;

    string resultadoMalo = "Que verguenza";
    string resultadoMedio = "Mediocre, pero safaste";
    string resultadoBueno = "Muy Bien!";

    int alternativaElegidaA;
    int alternativaElegidaB;
    int botonElegidoPrimero;
    PreguntasMatematicas preguntaActual;    

}

[System.Serializable]
public class PreguntaMatematicas
{
    public int valorTarget;
    public int[,] alternativas;
    [HideInInspector] public bool preguntaYaRealizada;
}
