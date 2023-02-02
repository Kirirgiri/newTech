using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Pepe;


public class RadarTrigger : MonoBehaviour
{
    public RadarElement element;
    private List<GameObject> registeredTargets = new List<GameObject>();
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "target")
        {
            other.GetComponent<RadarElement>().OnCreate();
        }
    }

    void OnTriggerLeave(Collider other)
    {
        other.GetComponent<RadarElement>().OnDestroy();
    }
}
