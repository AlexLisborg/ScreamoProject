using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IPlayer
{
    private float hp = 100;

    public void ChangeHP(float change)
    {
        Debug.Log("Chnaged hp " + change);
        hp += change;
    }

    public float getDir()
    {
        return (float)Math.PI;
    }

    public Vector2 getPos()
    {
        return transform.position + Vector3.zero;
    }

    public float getReach()
    {
        return 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
