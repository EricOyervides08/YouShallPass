using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goal : MonoBehaviour
{
    //puntaje que dara al llegar cada carro
    public int value = 10;

    //si un carro entra, anade puntaje y destruye instancia
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "car"){
            game_controller.score += value;
            Destroy(other.gameObject);
        }
    }
}
