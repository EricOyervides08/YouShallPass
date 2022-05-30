using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perpendicular_collider : MonoBehaviour
{
    //si esta libre o no
    public bool free = true;

    //conteo de carros
    public int count = 0;

    void FixedUpdate()
    {
        //si no hay carros en trigger esta libre, si hay no esta libre
        if (count > 0) {
            free = false;
        }
        else {
            free = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        //cuando entra un carro, si aun no lo contamos, sumar a cuenta y validamos que ya lo contamos
        if (other.tag == "car" && !other.GetComponent<perpendicular_detection>().validated) {
            count++;
            other.GetComponent<perpendicular_detection>().validated = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        //si se sale un carro, resetear valor de validacion y quitar uno a cuenta
        if (other.tag == "car" && other.GetComponent<perpendicular_detection>().validated) {
            count--;
            other.GetComponent<perpendicular_detection>().validated = false;
        }
    }
}
