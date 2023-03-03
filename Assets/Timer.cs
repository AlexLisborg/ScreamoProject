using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float defaultTime = 1.0f;
    private Dictionary<int, Tuple<Action, float>> timerStates = new Dictionary<int, Tuple<Action, float>>();
    private int nextFreeId = 0;

    public int StartTimer(Action onDone, float time)
    {
        Debug.Log("add " + nextFreeId + " with time " + time);
        timerStates.Add(nextFreeId, new Tuple<Action, float>(onDone, time));
        nextFreeId++;

        return nextFreeId - 1;
    }

    public void StopTimer(int id)
    {
        timerStates.Remove(id);
    }
    public int StartTimer(Action onDone)
    {
        return StartTimer(onDone, defaultTime);
    }


    void Update()
    {
        Dictionary<int, Tuple<Action,float>> timerNewStates =  new Dictionary<int, Tuple<Action, float>>();
        foreach (int id  in timerStates.Keys.ToList())
        {
            Tuple<Action,float> t = timerStates[id];
            if (t.Item2 > 0)
            {
                timerNewStates[id] = new Tuple<Action, float>(t.Item1, t.Item2 - Time.deltaTime);
            }
            else
            {
                t.Item1();
                Debug.Log("remove " + id);
            }
        }
        timerStates = timerNewStates;
    }

  
}
