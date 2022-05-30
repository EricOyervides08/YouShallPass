using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traffic_light : MonoBehaviour
{
    public GameObject[] lights;
    public string state = "";
    public bool green = true;
    public bool yellow;
    public bool red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (green)
            Green();
        else if (yellow)
            Yellow();
        else
            Red();
    }
    private void Green() 
    {
        if (lights[0].activeInHierarchy == false) {
        state = "Green";
        lights[0].SetActive(true);
        lights[1].SetActive(false);
        lights[2].SetActive(false);
        yellow = false;
        red = false;
        }
    }
    private void Yellow() 
    {
        if (lights[1].activeInHierarchy == false) {
        state = "Yellow";
        lights[0].SetActive(false);
        lights[1].SetActive(true);
        lights[2].SetActive(false);
        green = false;
        red = false;
        }
    }
    private void Red() 
    {
        if (lights[2].activeInHierarchy == false) {
            state = "Red";
            lights[0].SetActive(false);
            lights[1].SetActive(false);
            lights[2].SetActive(true);
            yellow = false;
            green = false;
        }
    }
}
