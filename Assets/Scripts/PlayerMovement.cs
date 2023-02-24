using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 v1 = new Vector3(0, 0, 0);

    //A list of the position of the tip of the gun for all aiming directions, used in GetGunFirePosition()
    private Vector3[] _firePositions = new Vector3[] { 
        new Vector3(-0.112f, -0.573f, 0), new Vector3(-0.468f, -0.37f, 0), new Vector3(0.478f, -0.325f, 0), //DD,DR,DL
        new Vector3(-0.841f, -0.251f, 0), new Vector3(-0.915f, 0.279f, 0), new Vector3(-0.791f, 0.576f, 0), //LD,LL,LU
        new Vector3(0.841f, -0.251f, 0), new Vector3(0.915f, 0.279f, 0), new Vector3(0.791f, 0.576f, 0), //RD,RR,RU
        new Vector3(-0.418f, 0.571f, 0), new Vector3(0.418f, 0.571f, 0), new Vector3(0, 0.814f, 0)}; //UL,UR,UU

    public Animator LegsAnim;

    public Animator BodyAnim;

    private float _defaultMovespeed = 2f;

    private float _moveSpeed;

    private Rigidbody2D _rigidBody;

    private Animator _animator;

    private Vector2 _movement;

    private Camera _camera;

    public GameObject _tester;

    public bool HoldGun;


    // Start is called before the first frame update
    void Start()
    {
    
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        _moveSpeed = _defaultMovespeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x,mousePos.y);
        Vector2 playerPos2D = new Vector2(transform.position.x,transform.position.y);
        Vector2 playerToMouse = (mousePos2D - playerPos2D).normalized;

        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        
        animSetFloat("MoveHorizontal", _movement.x);
        animSetFloat("MoveVertical", _movement.y);
        animSetFloat("Horizontal", playerToMouse.x);
        animSetFloat("Vertical", playerToMouse.y);
        animSetFloat("Speed", _movement.sqrMagnitude);
        BodyAnim.SetBool("HoldGun", HoldGun);
 
        if (!(playerToMouse.x > Mathf.Cos(Mathf.PI / 4f) && _movement.x > 0 ||
            playerToMouse.x < Mathf.Cos(Mathf.PI * (3f / 4f)) && _movement.x < 0 ||
            playerToMouse.y > Mathf.Sin(Mathf.PI / 4f) && _movement.y > 0 ||
            playerToMouse.y < Mathf.Sin(Mathf.PI + Mathf.PI * (3f / 4f)) && _movement.y < 0))
        {
            _moveSpeed = _defaultMovespeed / 2f;
        }
        else _moveSpeed = _defaultMovespeed;


        _tester.transform.position = transform.position + new Vector3(playerToMouse.x,playerToMouse.y,0);
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }
    private void animSetFloat(String s, float f)
    {
        LegsAnim.SetFloat(s, f);
        BodyAnim.SetFloat(s, f);
    }

    //Should return the position from which bullets should be instansiated when gun is fired.
    public Vector3 GetGunFirePosition()
    {
        throw new Exception("GetGunFirePosition() not implemented");
    }
}
