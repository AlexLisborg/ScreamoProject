using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static PlayerAudio;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 v1 = new Vector3(0, 0, 0);

    public Animator LegsAnim;

    public Animator BodyAnim;

    private float _defaultMovespeed = 3f;

    private float _moveSpeed;

    private Rigidbody2D _rigidBody;

    private PlayerAudio.PlayerEvent _currentMoveType;

    private Vector2 _movement;

    private Camera _camera;

    public bool HoldGun;

    private Vector2 playerToMouse = Vector2.up;

    private float _runTimer = 0f;

    private float _runEnergy;

    private float _runEnergyMax = 3;

    private Transform _firePosition;


    // Start is called before the first frame update
    void Start()
    {
        _currentMoveType = PlayerEvent.notMoving;
        _rigidBody = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
        _moveSpeed = _defaultMovespeed;
        _runEnergy = _runEnergyMax;
        _firePosition = transform.GetChild(1).GetChild(0).GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x,mousePos.y);
        Vector2 playerPos2D = new Vector2(transform.position.x,transform.position.y);
        playerToMouse = (mousePos2D - playerPos2D).normalized;

        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        _movement = _movement.normalized;

        animSetFloat("MoveHorizontal", _movement.x);
        animSetFloat("MoveVertical", _movement.y);
        animSetFloat("Horizontal", playerToMouse.x);
        animSetFloat("Vertical", playerToMouse.y);
        animSetFloat("Speed", _movement.sqrMagnitude);
        BodyAnim.SetBool("HoldGun", HoldGun);

        if (!(playerToMouse.x > Mathf.Cos(Mathf.PI / 4f) && (_movement.x >= 0) ||
            playerToMouse.x < Mathf.Cos(Mathf.PI * (3f / 4f)) && _movement.x <= 0 ||
            playerToMouse.y > Mathf.Sin(Mathf.PI / 4f) && _movement.y >= 0 ||
            playerToMouse.y < Mathf.Sin(Mathf.PI + Mathf.PI * (3f / 4f)) && _movement.y <= 0))
        {
            _moveSpeed = _defaultMovespeed / 1.5f;
        }
        else {

            if (_runTimer >= 1)
            {
                if (_runTimer <= 2)
                {
                    _runTimer += Time.deltaTime;
                }
                else
                {
                    _runTimer = 0;
                }
                
            }
            if (_runEnergy <= 0)
            {
                _runTimer = 1;
            }
            if (Input.GetKey(KeyCode.LeftShift) && _movement.sqrMagnitude > 0 && _runEnergy >= 0 && _runTimer == 0)
            {
                _moveSpeed = _defaultMovespeed * 2f;
                _runEnergy -= Time.deltaTime;
            }
            else
            {
                if (_runEnergy <= _runEnergyMax) _runEnergy += (Time.deltaTime / 2f);
                _moveSpeed = _defaultMovespeed;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidBody.MovePosition(_rigidBody.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        UpdateMovementAudio();
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

    public void SetHoldGun(bool b)
    {
        HoldGun = b;
    }

    public Vector2 GetPlayerToMouse()
    {
        return playerToMouse;
    }

    public Vector3 GetCurrentFirePosition()
    {
        return _firePosition.position;
    }

    private void UpdateMovementAudio(PlayerEvent newMovement)
    {
        if (newMovement != _currentMoveType)
        {
            _currentMoveType = newMovement;
            gameObject.GetComponent<PlayerAudio>().source.Stop();
            if (newMovement != PlayerEvent.notMoving)
            {
                PlayAudio(newMovement);
            }
        }
    }

    private void UpdateMovementAudio()
    {
        if(_movement.x == 0 && _movement.y == 0)
        {
            UpdateMovementAudio(PlayerEvent.notMoving);
        }
        else if (_moveSpeed > 2.1f)
        {
            UpdateMovementAudio(PlayerEvent.running);
        }
        else if (_moveSpeed < 2.1f && _moveSpeed > 1.9f)
        {
            UpdateMovementAudio(PlayerEvent.walking);
        }
        else
        {
            UpdateMovementAudio(PlayerEvent.walkingBackwards);
        }
    }

    // Checks if audio script is null before playing audio
    private void PlayAudio(PlayerEvent playerEvent)
    {
        if (gameObject.GetComponent<PlayerAudio>() != null)
        {
            gameObject.GetComponent<PlayerAudio>().PlayAudio(playerEvent);
        }
        else
        {
            Debug.Log("Script was null");
        }
    }
}
