using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Pepe;


public class RadarTrigger : MonoBehaviour
{
    // adds targets to the radar directory
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "target" || other.gameObject.tag == "pickups")
        {
            other.GetComponent<RadarElement>().OnCreate();
        }
    }

    private void OnTriggerLeave(Collider other)
    {
        other.GetComponent<RadarElement>().OnDestroy();
    }
}
