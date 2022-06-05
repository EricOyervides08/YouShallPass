using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_target : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float timeTarget;
    [SerializeField]
    private AnimationCurve curve;
    private bool inTransition;
    private float transitionTime;
    private Vector3 pastPosition;
    private Vector3 goalPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inTransition)
        {
            transitionTime += Time.deltaTime;
  
            Vector3 newPos = Vector3.zero;
            newPos.x = curve.Evaluate(transitionTime / timeTarget) * (goalPos.x-pastPosition.x) + pastPosition.x;
            newPos.y = curve.Evaluate(transitionTime / timeTarget) * (goalPos.y - pastPosition.y) + pastPosition.y;
            newPos.z = curve.Evaluate(transitionTime / timeTarget) * (goalPos.z - pastPosition.z) + pastPosition.z;
            transform.position = newPos;
            if (transform.position == goalPos)
            {
                inTransition = false;
            }
            if (target.position + offset != goalPos)
            {
                transitionTime = 0;
                pastPosition = transform.position;
                goalPos = target.position + offset;
            }
        }
        else
        {
            transitionTime = 0;
            if (transform.position + offset != target.position)
            {
                pastPosition = transform.position;
                goalPos = target.position + offset;
                inTransition = true;
            }
        }
        
    }
}
