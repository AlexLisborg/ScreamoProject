using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : ItemScript
{
    [SerializeField] float movementSpeed;
    private Vector3 _movement;
    private bool hasBeenShot = false;

    public override Activation getActivation()
    {
        return new Activation();
    }

    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }


    public void shoot(IPlayer player)
    {
        transform.position = player.getPlayerHandsPosition();
        _movement = player.getDir();
        hasBeenShot = true;
        gameObject.SetActive(true);

    }

    public void Update()
    {
        if (hasBeenShot)
        {
            transform.position += _movement * Time.deltaTime * movementSpeed;
        }
    }
}
