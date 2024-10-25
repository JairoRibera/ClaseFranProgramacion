using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPuzzle : MonoBehaviour
{
    //Todas las areas que hagan falta para resolver puzzles
    public ColorArea[] areas;
    // objeto que queremos desactivar
    public GameObject obstacle;

    void Update()
    {
        //Hacemos una variable que cuente cuantas areas estan correctas
        int _correctAreas = 0;
        //Cada vez que encuentre un area correcta, suma 1 al contador de areas
        foreach (ColorArea area in areas)
        {
            if(area.isCorrect == true)
            {
                _correctAreas++;
            }

        }
        //COmprobar si hay tantas areas correctas como elementos dentro del array
        if (_correctAreas == areas.Length)
        {
            //Si se cumple se ha completado el puzzle
            obstacle.SetActive(false);
        }
        //else
        //    obstacle.SetActive(true);
    }
}
