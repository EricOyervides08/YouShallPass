using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    private enum LightState
    {
        Green,
        Red,
        Yellow
    }

    private const float _YELLOW_STATE_TIME = 1.5f;

    public int currState = (int) LightState.Red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeStateTo(LightState state)
    {
        if (state == LightState.Red)
        {
            ChangeStateTo(LightState.Yellow);
            WaitYellowLight();
        }

        // cambiar color
        currState = (int) state;
    }

    IEnumerator WaitYellowLight()
    {
        yield return new WaitForSeconds(_YELLOW_STATE_TIME);
    }
}
