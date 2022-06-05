using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public traffic_light currentLight;
    public Transform cameraTarget;
    // Start is called before the first frame update
    void Start()
    {
        cameraTarget.position = currentLight.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentLight.Change();
        }

        traffic_light next = null;
        if (Input.GetKeyDown(KeyCode.A))
        {
            next = currentLight.GetComponent<next_traffic_lights>().left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            next = currentLight.GetComponent<next_traffic_lights>().right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            next = currentLight.GetComponent<next_traffic_lights>().up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            next = currentLight.GetComponent<next_traffic_lights>().down;
        }

        if (next != null)
        {
            currentLight = next;
            cameraTarget.position = currentLight.transform.position;
        }
    }
}
