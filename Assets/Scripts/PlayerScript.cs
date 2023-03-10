using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IPlayer
{
    private float hp = 100;

    [SerializeField] private PlayerMovement pm;
    [SerializeField] private Inventory inventory;


    public void ChangeHP(float change)
    {
        Debug.Log("Chnaged hp " + change);
        hp += change;
    }

   

    public Vector3 getDir()
    {
        return new Vector3(pm.GetPlayerToMouse().x,pm.GetPlayerToMouse().y,0);
    }

    public Inventory getInventory()
    {
        return GetComponent<Inventory>();   
    }

    public Vector2 getPlayerHandsPosition()
    {
        return getPos();
    }

    public Vector2 getPos()
    {
        return transform.position + Vector3.zero;
    }

    public float getReach()
    {
        return 1.5f;
    }

    public void setHoldingPostil(bool holding)
    {
        GetComponent<PlayerMovement>().SetHoldGun(holding);
    }

 
}
