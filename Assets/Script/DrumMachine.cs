using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DrumMachine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI volumenDisplay;
    [SerializeField] Slider volumenContol;
    [SerializeField] AudioSource[] elementosBateria;

 public void TocarElementoBateria(int index)
    {
        elementosBateria[index].Play();
    }
    public void CambiarVolumen()

    {
        float volumenActualSlider = volumenContol.value;

        volumenDisplay.text = (volumenActualSlider * 100f).ToString("0")+"%";

        /*
        elementosBateria[0].volume = volumenActualSlider;
        elementosBateria[1].volume = volumenActualSlider;
        elementosBateria[2].volume = volumenActualSlider;
        elementosBateria[3].volume = volumenActualSlider;
        elementosBateria[4].volume = volumenActualSlider;
        elementosBateria[5].volume = volumenActualSlider;
        */
        foreach (AudioSource a in elementosBateria)
        {
            // "a" o "index" es predicado,
            // es decir, nombre corto para llamar a la variable por citar.
            a.volume = volumenActualSlider;  
        }
    }
}
