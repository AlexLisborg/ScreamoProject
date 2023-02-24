using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Transform target;
    
    private void Update()
    {
        if (target != null)
        {
            float travel = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, travel);
        }
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
        }
    }
}
