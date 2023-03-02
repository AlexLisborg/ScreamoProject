using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float defaultTime = 1.0f;
    private float timeRemaining;
    private Action onDone;
    private bool going;


    public void StartTimer(Action onDone, float time)
    {   
        if (!going)
        {
            this.onDone = onDone;
            going = true;
            this.timeRemaining = time;
        }
    }

    public void StopTimer()
    {
        going = false;
        onDone = null;
    }
    public void StartTimer(Action onDone)
    {
        StartTimer(onDone, defaultTime);
    }


    void Update()
    {
        if (going){
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                onDone();
                going = false;
            }
        }
    }
}
