using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControler : MonoBehaviour
{
    public bool hasKey = false;
    public Inventario inventario;
    private GameObject i;
    // Start is called before the first frame update
    void Start()
    {
        //FindAnyObjectByType busca objetos por scripts, es recomendable buscar cuando hay un objeto con un solo scripts

        inventario = FindAnyObjectByType<Inventario>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //si el objeto no es el jugado no se ejecuta la funcion
        if (other.CompareTag("Player") == false)
        {
            return;
        }
        //Oara que funcione cada puerta con su llave correspondiente
        //if (hasKey == true)
        //    gameObject.SetActive(false);
        //else
        //    Debug.Log("Necesitas una llave");
        //Para que la llave abra todas las puertas
        if (inventario.key1 == true)
            gameObject.SetActive(false);
        else
            Debug.Log("Necesitas una llave");
    }
}

