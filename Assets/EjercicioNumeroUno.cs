using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EjercicioNumeroUno : MonoBehaviour
{
    enum EstadosJuego {RellenarInterfaz,EsperarInputA, EsperarInputB,RealizarComprobacion,RevisarSiSigueEnElJuego,MonstrarResultados,Salida}
    [SerializeField]EstadosJuego estado;
    [Space(30)]
    [SerializeField] TextMeshProUGUI puntaje;         // ACA TENGO MI TMPRO DONDE VOY A MOSTRAR EL PUNTAJE ACTUAL

    [SerializeField] TextMeshProUGUI valorJugadorA;   // ACA VOY A MOSTRAR LA ALTERNATIVA UNO QUE ELIJIO EL JUGADOR 
    [SerializeField] TextMeshProUGUI valorJugadorB;  
    [SerializeField] TextMeshProUGUI valorResultado;
    [SerializeField] TextMeshProUGUI frasePuntuacion;


    [SerializeField] TextMeshProUGUI[] alternativas;
    [Space(20)]
    [SerializeField] PreguntasMatematicas[] preguntas;
 
    // PUNTAJE 
    int puntajeJugador;
    int puntajePorPregunta = 1;
   
    // PREGUNTAS HECHAS
    int cantidadDePreguntas;
    int preguntasMaximas = 11;
    
    // TEXTO RESULTADOS
    string resultadoMalo  = "Que vergueza";
    string resultadoMedio = "Mediocre,pero pasaste";
    string resultadoBueno = "Muy Bien";
   
    // INFO DE PREGUNTAS HECHAS
    int alternativaElegidaA;
    int alternativaElegidaB;
    int botonElegidoPrimero;
    PreguntasMatematicas preguntaActual;



    // ESTE METODO BUSCA DENTRO DE MI ARREGLO DE PREGUNTAS Y ME VA A DAR UNA QUE NO SE ESTE USANDO
    void BuscadorYRellenadorDePregunta()
    {
        // BUSCAMOS UNA PREGUNTA AL AZAR
        do
        {
            preguntaActual = preguntas[Random.Range(0, preguntas.Length)];
        }
        while (preguntaActual.preguntaYaFueRealizada); // REVISAMOS QUE LA PREGUNTA NO FUE UTILIZADA ANTERIORMENTE

        preguntaActual.preguntaYaFueRealizada = true;  // LE DECIMOS A NUESTRO "SYSTEMA" QUE YA USAMOS LA PREGUNTA

        // UTILZAMOS LA INFORMACION DE ALTERNATIVAS Y RELLENAMOS NUESTROS BOTONES
        for (int i=0;i < alternativas.Length ;i++)
        {
            alternativas[i].text = preguntaActual.alternativas[i].ToString(); 
        }

        // UTILIZAMOS LA INFORMACION DE VALOR TARGET Y PONEMOS ESE VALOR EN LA PANTALLA
        valorResultado.text = preguntaActual.valorTarget.ToString();

        valorJugadorA.text = "";
        valorJugadorB.text = "";


    }

    // LE PIDO AL JUGADOR LA PRIMERA OPCION
    void EntradaDeOpcionA(int numeroDelBoton)
    {
        botonElegidoPrimero = numeroDelBoton;
        alternativaElegidaA = preguntaActual.alternativas[numeroDelBoton];
        valorJugadorA.text = alternativaElegidaA.ToString();
        estado = EstadosJuego.EsperarInputB;

    }

    // LE PIDO AL JUGADOR LA SEGUNDA OPCION
    void EntradaDeOpcionB(int numeroDelBoton)
    {
        if (numeroDelBoton == botonElegidoPrimero) return;
        alternativaElegidaB = preguntaActual.alternativas[numeroDelBoton];
        valorJugadorB.text = alternativaElegidaB.ToString();
        estado = EstadosJuego.RealizarComprobacion;

    }

    // ESTE METODO PIDE LOS BOTONES Y SEPARA EL ESTADO DEL JUEGO
    public void InputUsuario(int numeroDelBoton)
    {
        switch (estado)
        {         
            case EstadosJuego.EsperarInputA:
                EntradaDeOpcionA(numeroDelBoton);
              
                break;

            case EstadosJuego.EsperarInputB:
                EntradaDeOpcionB(numeroDelBoton);
              
                break;          
        }


    }



    // CON ESTE METODO REVISO SI LAS OPCIONES ELEJIDAS POR EL JUGADOR SUMAN EL NUMERO ESPERADO
    void ComprobarSiElResultadoEsElCorrecto()
    {
        if (alternativaElegidaA + alternativaElegidaB == preguntaActual.valorTarget)
        {
            puntajeJugador += puntajePorPregunta;
            puntaje.text = puntajeJugador.ToString();
        }
    }

    // EN ESTA FUNCION REVISO SI EL JUEGO CONTINUA O NO
    bool ContadorDePreguntasSiguientePregunta()
    {
        cantidadDePreguntas++;

        return cantidadDePreguntas < preguntasMaximas; 
    }

    // EN ESTA FUNCION MUESTRO LOS RESULTADOS
    void MuestroResultados()
    {
        if (puntajeJugador <= 6)
        {
            frasePuntuacion.text = resultadoMalo;
        }
        else if (puntajeJugador > 6 || puntajeJugador >= 9)
        {
            frasePuntuacion.text = resultadoMedio;
        }
        else
        {
            frasePuntuacion.text = resultadoBueno;
        }


    }

    private void Start()
    {
        puntaje.text = "0";
    }

    private void Update()
    {
        switch (estado)
        {
            case EstadosJuego.RellenarInterfaz:
                BuscadorYRellenadorDePregunta();
                estado = EstadosJuego.EsperarInputA;
                break;
            case EstadosJuego.EsperarInputA:
                break;
            case EstadosJuego.EsperarInputB:
                break;
            case EstadosJuego.RealizarComprobacion:
                ComprobarSiElResultadoEsElCorrecto();
                estado = EstadosJuego.RevisarSiSigueEnElJuego;
                break;
            case EstadosJuego.RevisarSiSigueEnElJuego:
                if (ContadorDePreguntasSiguientePregunta())
                {
                    estado = EstadosJuego.RellenarInterfaz;
                }
                else
                {
                    estado = EstadosJuego.MonstrarResultados;
                }

                break;
            case EstadosJuego.MonstrarResultados:
                MuestroResultados();
                estado = EstadosJuego.Salida;
                break;

            case EstadosJuego.Salida:
                break;
        }
    }




}

[System.Serializable]
public class PreguntasMatematicas
{
    public int valorTarget;
    public int[] alternativas;
    [HideInInspector] public bool preguntaYaFueRealizada;

}