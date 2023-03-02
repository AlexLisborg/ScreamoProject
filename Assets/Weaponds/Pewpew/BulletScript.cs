using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : InactiveItem
{
    [SerializeField] float movementSpeed;
    private Vector3 _movement;
    private bool hasBeenShot = false;

    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }


    public void shoot(IPlayer player)
    {
        transform.position = player.getPlayerHandsPosition();
        gameObject.SetActive(true);
        _movement = player.getDir();
        hasBeenShot = true;
    }

    private void Update()
    {
        if (hasBeenShot)
        {  
            transform.position += _movement * Time.deltaTime * movementSpeed;
        }
    }




}
