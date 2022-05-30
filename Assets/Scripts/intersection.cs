using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intersection : MonoBehaviour
{
    public string[] directions;
    public perpendicular_collider perpendicular_collider; 
    public traffic_light perpendicularTrafficLight;
    public traffic_light traffic_light;

    //elegir entre direcciones disponibles y regresar uno al azar
    public int assignDirection() {
        return Random.Range(0, directions.Length);
    }

    //regresa string de direccion recibiendo el index
    public string getDirection(int n)
    {
        return directions[n];
    }

    //regresa la disponibilidad de direccion indicada
    public bool Available(int n) {
        //si la direccion es para el frente, checar si esta en verde
        if (directions[n] == "Front") {
            if (traffic_light.state == "Green") {
                return true;
            }
        }
        //si va para la derecha checar si no hay nadie en el prependicular collider o si el semaforo perpendicular este en rojo
        else if (directions[n] == "Right") {
            if (perpendicular_collider.free || perpendicularTrafficLight.state == "Red")
                return true;
        }

        return false;
    }
}
