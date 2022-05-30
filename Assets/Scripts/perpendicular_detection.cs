using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perpendicular_detection : MonoBehaviour
{
    public bool validated;
    public bool inside = false;
    public GameObject volume;

    void Awake() {
        validated = false;
    }

    void FixedUpdate () {
    //     if (volume != null){
    //         if (inside) {
    //             if (!validated) {
    //                 volume.GetComponent<perpendicular_collider>().count++;
    //                 validated = true;
    //             }
    //         }
    //         else {
    //             if (validated) {
    //                 validated = false;
    //                 volume.GetComponent<perpendicular_collider>().count--;
    //                 volume = null;
    //             }
    //         }
    //     }
    //     inside = false;
    // }
    // private void OnTriggerStay(Collider other) {
    //     if (other.gameObject.GetComponent<perpendicular_collider>() != null && GetComponent<BoxCollider>().isTrigger ==) {
    //         if (!validated) {
    //             volume = other.gameObject;
    //         }
    //         inside = true;
    //     }
    }
}
