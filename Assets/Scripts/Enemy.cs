using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _playerTransform;
    private Rigidbody2D _rigidbody;
    private float _speed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Vector2 toPlayer2D = new Vector2(toPlayer.x, toPlayer.y).normalized;
        _rigidbody.MovePosition(_rigidbody.position + toPlayer2D * 0.01f * _speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(transform.gameObject);
    }
}
