using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class RadarTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent detectingTargets;
    [SerializeField] private List<GameObject> targets;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        for(var i=0;i<targets.Count;i++)
        {
            if(other == targets[i])
            {
                Debug.Log("FSDGDSGSDg");
            }
        }
    }
}
