using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traffic_light : MonoBehaviour
{
    public GameObject[] lights;
    public string state = "";
    public float yellowTime = 1;
    public bool green = true;
    public bool yellow;
    public bool red;

    public bool inTransition = false;
    private float transitionTime = 0;
    private string goal = "Red";

    // Start is called before the first frame update
    void Start()
    {
        inTransition = false;
        state = "Red";
        goal = state;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inTransition)
        {
            transitionTime = 0;
            if (state == "Green")
                Green();
            if (state == "Red")
                Red();
            if (state == "Yellow")
                Yellow();
            if (state != goal)
            {
                inTransition = true;
            }
        }
        else
        {
            transitionTime += Time.deltaTime;
            if (goal == "Green")
            {
                state = "Green";
                Green();
                inTransition = false;
            }
            if (goal == "Red")
            {
                if (transitionTime < yellowTime)
                {
                    state = "Yellow";
                    Yellow();
                }
                else
                {
                    state = "Red";
                    Red();
                    inTransition = false;
                }
            }
        }
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

    public void Change()
    {
        if (goal == "Red")
        {
            goal = "Green";
        }
        else if (goal == "Green")
        {
            goal = "Red";
        }
    }

}
