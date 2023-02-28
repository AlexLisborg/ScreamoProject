using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Func<Vector2> target;
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (target != null)
        {
            float travel = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target(), travel);
            
            Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);
            Vector2 _movement = (target() - pos2d).normalized;
            _anim.SetFloat("Horizontal",_movement.x);
            _anim.SetFloat("Vertical",_movement.y);
            _anim.SetFloat("Speed",_movement.sqrMagnitude);

        }
    }

    public void setTarget(Func<Vector2> target)
    {
        this.target = target;
    }

   
}
