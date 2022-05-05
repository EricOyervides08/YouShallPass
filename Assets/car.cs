using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public float targetVelocity;
    public float velocity = 0;
    public float acceleration;
    public float brakeSpeed;

    public bool steer;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    void Steer() {
        if (velocity < targetVelocity) {
            velocity += acceleration * Time.deltaTime;
        }
        else {
            velocity = targetVelocity; 
        }
        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.Self);
    }
    void Brake(){
        if (velocity > 0) {
            velocity -= acceleration * Time.deltaTime;
        }
        else {
            velocity = 0; 
        }
        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.Self);
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "car") {
            steer = false;
        }
        if (other.gameObject.tag == "intersection") {
            steer = false;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "car") {
            steer = true;
        }
    }
}
