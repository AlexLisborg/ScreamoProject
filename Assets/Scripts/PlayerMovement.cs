using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float MovementSpeed;

    private Rigidbody2D _rigidBody;

    private Vector2 _movement;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

    }

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * MovementSpeed * Time.fixedDeltaTime);
    }
}
