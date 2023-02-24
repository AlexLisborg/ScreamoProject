using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Func<Vector2> target;
    
    private void Update()
    {
        if (target != null)
        {
            float travel = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target(), travel);
        }
    }

    public void setTarget(Func<Vector2> target)
    {
        this.target = target;
    }

   
}
