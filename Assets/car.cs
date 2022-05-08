using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    //Velocity
    public float targetVelocity;
    public float velocity = 0;

    //Acceleration
    public float acceleration;
    public float initialAcceleration;

    //Steer
    public bool steer;

    //Front raycast
    public float rayStart;
    public float rayDistance;
    public bool hasStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        initialAcceleration = acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        if (steer) {
            Steer();
        }
        else {
            Brake();
        }
        //Draw front raycast
        Debug.DrawRay(transform.position + Vector3.forward * rayStart, Vector3.forward * rayDistance);
    }

    void Steer() {
        //cambiar gradualmente la variable velocidad
        if (velocity < targetVelocity) {
            velocity += acceleration * Time.deltaTime;
        }
        else {
            velocity = targetVelocity; 
        }
        //moverlo dependiendo de la velocidad
        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.Self);
    }
    void Brake(){
        //cambiar gradualmente hasta 0
        if (velocity > 0) {
            velocity -= acceleration * Time.deltaTime;
        }
        else {
            velocity = 0; 
        }
        //moverlo dependiendo de la velocidad
        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.Self);
    }

    private void OnTriggerStay(Collider other) {

        //detectar si es algun trigger que detenga
        bool stopTrigger = false;

        //si es carro
        if (other.gameObject.tag == "car") {
            steer = false;
            stopTrigger = true;
        }

        //si es interseccion (va a cambiar en el futuro)
        if (other.gameObject.tag == "intersection") {
            steer = false;
            stopTrigger = true;
        }

        //cuando se detiene, hacer raycast para acercarse lo mas posible
        if ((velocity == 0 || hasStopped) && stopTrigger) {
            Debug.Log("Acomodandose");
            hasStopped = true;

            //raycast hacia el frente, si se detecta, frenar con doble de aceleracion
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.forward * rayStart, Vector3.forward, out hit, rayDistance) 
            && (hit.transform.gameObject.tag == "car" || hit.transform.gameObject.tag == "intersection")) {
                steer = false;
                acceleration = initialAcceleration * 2;
                Debug.Log("Raycast hit");
            }
            else {
                acceleration = initialAcceleration;
                steer = true;
            }
        }
        else {
            Debug.Log(" ");
        }
    }
    private void OnTriggerExit(Collider other) {
        //al salirse el carro del frente del trigger, resetear variables
        if (other.gameObject.tag == "car") {
            steer = true;
            hasStopped = false;
        }
    }
}
