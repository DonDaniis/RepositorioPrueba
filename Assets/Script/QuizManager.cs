using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pregunta;
    [SerializeField] TextMeshProUGUI alternativaA;
    [SerializeField] TextMeshProUGUI alternativaB;
    [SerializeField] TextMeshProUGUI alternativaC;
    [SerializeField] TextMeshProUGUI alternativaD;
    [SerializeField] PreguntasAlternativas[] TotalDePreguntas;
    [SerializeField] PreguntasAlternativas preguntaTarget;
    //puntajes editados por mi, no estoy seguro que funcione
    [SerializeField] TextMeshProUGUI PuntajeActual;
    [SerializeField] TextMeshProUGUI PuntajeMax;

    float tiempoDeEspera = .5f;
    float conteoTiempoEspera;
    bool startCount;
    int alternativaElegida;
    int puntajeActual;
    int puntajeMaximo;
    //agregado de otro ejercicio numérico
    int preguntasMaximas = 10;
    int puntajePorPregunta = 100;
    //frases nuevas. Creadas de juego matemático
    string resultadoMalo = "lograbas más puntos con un un golpe en la cabeza, que jugando";
    string resultadoMedio = "segundo lugar, el mejor de los peores";
    string resultadoBueno = "el peor cinismo es creer en la suerte. Bien hecho campeón";

    private void Start()
    {//nuevo ingreso
        PlayerPrefs.SetFloat("PuntajeMaximo", 0f);
        PuntajeMax.text = PlayerPrefs.GetFloat("PuntajeMaximo").ToString();

    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("PuntajeMaximo"))
        {
            PlayerPrefs.SetInt("PuntajeMaximo", 0f);
        }

        if (!PlayerPrefs.HasKey("PuntajeActual"))
        {
            PlayerPrefs.SetInt("PuntajeActual", 0f);

        }
        puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo");
    }

    private void Update()
    {
        if (startCount)
        {
            conteoTiempoEspera += Time.deltaTime;

            if (conteoTiempoEspera >= tiempoDeEspera)
            {
                
                startCount = false;
                conteoTiempoEspera = 0f;

                ComprobarVerdaderoOFalso();

            }

        }
    }
    [ContextMenu("FETCH PREGUNTAS")]
    void GenerarPregunta()
    {//nuevo ingreso Do While (POSIBLE ERROR)
       
        do
        {
            preguntaTarget = TotalDePreguntas[Random.Range(0, TotalDePreguntas.Length)];
        }
        while (!preguntaTarget.PreguntaYaFueRealizada);

        preguntaTarget.PreguntaYaFueRealizada = true;

        //arreglo anterior no editado
        int index = Random.Range(0,TotalDePreguntas.Length);
        preguntaTarget = TotalDePreguntas[index];

       
        

        pregunta.text = preguntaTarget.pregunta;
        alternativaA.text = preguntaTarget.alternativas[0];
        alternativaB.text = preguntaTarget.alternativas[1];
        alternativaC.text = preguntaTarget.alternativas[2];
        alternativaD.text = preguntaTarget.alternativas[3];
    }

    void ComprobarVerdaderoOFalso()
    {
      if (preguntaTarget.correctas[alternativaElegida])
        {
            puntajeActual += 100;

        }
      else
        {
            Debug.Log("INCORRECTA");
        }
    }

    void CompararSiPuntajeActualEsMayorQueElMaximo()
    {
        if (puntajeActual > puntajeMaximo)
        {
            PlayerPrefs.SetInt("PuntajeMaximo", puntajeActual);
        }
    }

    public void StartCounter(int boton)
    {
        startCount = true;
        alternativaElegida = boton;
    }

    [System.Serializable]
    public class PreguntasAlternativas
    {
        public string pregunta;

        public string[] alternativas;

        public bool[] correctas;
        //nuevo ingreso
        [HideInInspector] public bool PreguntaYaFueRealizada;
    }
}