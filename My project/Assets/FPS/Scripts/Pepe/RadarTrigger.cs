using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Pepe;


public class RadarTrigger : MonoBehaviour
{
    // Start is called before the first frame update
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
