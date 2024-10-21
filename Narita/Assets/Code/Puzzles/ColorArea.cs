using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorArea : MonoBehaviour
{
   
    public ColorType type;
    public bool isCorrect = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Acceder al componente coloritem del objeto que haya entrado en el area
        ColorItem _item = other.GetComponent<ColorItem>();
        //Si ha encontrado un scrupt Color Item
        if(_item != null && type == _item.type)
        {
            isCorrect = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Acceder al componente coloritem del objeto que haya entrado en el area
        ColorItem _item = other.GetComponent<ColorItem>();
        //Si ha encontrado un scrupt Color Item
        if (_item != null && type == _item.type)
        {
            isCorrect = false;
        }
    }
}