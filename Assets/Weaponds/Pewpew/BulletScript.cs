using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : InactiveItem
{
    [SerializeField] float movementSpeed;
    private bool hasBeenShot = false;

    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }


    public void shoot(IPlayer player)
    {
        transform.position = player.getPlayerHandsPosition();
        gameObject.SetActive(true);
        transform.eulerAngles = new Vector3(0,0,player.getDir());
        hasBeenShot = true;
    }

    private void Update()
    {
        if (hasBeenShot)
        {
            float angle = transform.eulerAngles.z;
            transform.position += new Vector3(0, Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle)) * Time.deltaTime * movementSpeed;
        }
    }




}
