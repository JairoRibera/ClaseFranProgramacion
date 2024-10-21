using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public DoorControler doorToOpen;
    public Inventario inventario;
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") == true)
        {
            //Cambiamos el valor del bool de la puerta a true
            //doorToOpen.hasKey = true;
            //Canbiar el bool del inventario para abrir todas las puertas1
            inventario.key1 = true;
            Destroy(gameObject);
        }

    }
}
