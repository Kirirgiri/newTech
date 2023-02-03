using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sweepAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform radarSweep;
    [SerializeField] private AudioSource beep;
    private int count = -70;
    void Start()
    {
        beep.GetComponent<AudioSource>().Stop();
    }
    void Update()
    {
        if(count<70)
        {
            radarSweep.anchoredPosition = new Vector2(count,radarSweep.anchoredPosition.y);
            count++;
        }else{
            count = -70;
            beep.GetComponent<AudioSource>().Play();
        }
    }
}
