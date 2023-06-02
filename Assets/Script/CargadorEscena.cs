using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CargadorEscena : MonoBehaviour
{
    [SerializeField] string escenaInicio;
    [SerializeField] string escenaQuiz;
    [SerializeField] string escenaPuntaje;
    
    public void CargarEscenaInicio()
    {
        SceneManager.LoadScene(escenaInicio);
    }

    public void CargarEscenaPuntaje()
    {
        SceneManager.LoadScene(escenaPuntaje);
    }
   
    public void CargarEscenaJuego()
    {
        SceneManager.LoadScene(escenaQuiz);
    }
}



