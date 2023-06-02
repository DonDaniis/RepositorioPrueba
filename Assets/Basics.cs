using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basics : MonoBehaviour
{
    bool verdaderoOFalso;
    int numerosEnteros; // puede ser + o -
    char caracteres = '/';
    string cadenasDeCaracters = "A";
    char[] arregloDeChars;
    float valoresDecimales; // puede ser + o -

    #region MiCodigoViejo

    void MiFuncionUno()
    {
        Debug.Log("Esta es mi funcion uno");//<---propio de unity
        char miChar = cadenasDeCaracters[3];
    }
    bool NumeroPrimeroEsMayor(int primero,int segundo)
    {
        return primero > segundo;
    }
    int nmbA=2;
    int nmbB=3;
    void FuncionTres(int primero, int segundo)
    {
        if (NumeroPrimeroEsMayor(primero, segundo))
        {
            FuncionTres(2,4);   // RECURSION
        }
     }
    int SumaDosNumeros(int primero, int segundo)
    {
        return primero+segundo;
    }
    string DevuelveUNaPalabra()
    {
        return "Hola";
    }
    
    // == igual a
    // != diferente a
    // > Mayor a 
    // < Menor a
    // >= Mayor o igual
    // <= Menor o igual
    // && y
    // || o
    bool boolA = true;
    bool boolB = false;

    void FuncionDuda()
    {
        if (a == b) // esta se ejecuta cuando es verdadera
        {

        }
        else if (a > b) // se ejecuta si la anterior no es verdadera y esta si lo es
        {

        }
        else // Se ejcuta cuando ninguna de las anteriores es verdadera 
        {

        }




    }
    #endregion

    string animalA = "Perro";
    string animalB = "Gato";
    string animalC = "Mapache";


    void FuncionEnredo(string af)
    {
        #region codigoNoOptimo
        /* 
        if (af == animalA)
        {
            Debug.Log(" Tu animal favorito es el mismo que el de Jose");
        }
        else if (af == animalB)
        {
            Debug.Log(" Tu animal favorito es el mismo que el de Sebastian");
        }
        else if (af == animalC)
        {
            Debug.Log(" Tu animal favorito es el mismo que el de Andres");
        }
        else
        {
            Debug.Log(" Tu animal favorito es diferente al de todos");
        }
        */
        #endregion

        switch (af)
        {
            case "Perro":
                Debug.Log(" Tu animal favorito es el mismo que el de Jose");
                break;

            case "Gato":
                Debug.Log(" Tu animal favorito es el mismo que el de Sebastian");
                break;

            case "Mapache":
                Debug.Log(" Tu animal favorito es el mismo que el de Andres");
                break;

            default:
                Debug.Log(" Tu animal favorito es diferente al de todos");
                break;
        }

      


    }


    int a = 2;
    int b = 3;
    int c = 5;
    int d = 6;

    int codigoSecreto;

    void FuncionDelta()
    {
        // Do - While         // While        // For        // Foreach

        while (a < 0 )
        {
               a++;
        }

        do
        {
            codigoSecreto = Random.Range(0, 9999);
        }
        while (codigoSecreto>=1000);

        string[] palabras = new string[] { "Perro", "Gato", "Mapache" };

        int countPalabras=0;

        foreach (string p in palabras)
        {
            countPalabras++;
        }
        Debug.Log("La Longitud de palabras es " + palabras.Length);

        int[] cantidadDeLetras;
        string[] todasMisPalabras = new string[] { "Perro", "Gato", "Mapache", "Capibara", "Leon" };

        cantidadDeLetras = new int[todasMisPalabras.Length];

        for (int i=0; i<cantidadDeLetras.Length ;i++ )
        {
            cantidadDeLetras[i] = todasMisPalabras[i].Length;
        }



    }

}
