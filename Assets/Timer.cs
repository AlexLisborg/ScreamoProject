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
        this.onDone= onDone;
        going = true;
        this.timeRemaining = time;
    }
    public void StartTimer(Action onDone)
    {
        StartTimer(onDone, timeRemaining);
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
                Destroy(gameObject);
            }
        }
    }
}
