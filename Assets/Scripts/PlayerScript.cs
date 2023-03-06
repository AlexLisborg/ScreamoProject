using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour, IPlayer
{
    private float hp = 100;

    [SerializeField] private GameObject HPIndicator;
    [SerializeField] private Color zeroHealthColor;
    [SerializeField] private PlayerMovement pm;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject _deathMouth;
    private SpriteRenderer sr;
    private void Start()
    {
        sr = HPIndicator.GetComponent<SpriteRenderer>();
    }
    float deathTimer = 0;
    [Obsolete]
    private void Update()
    {
        if(hp <= 0)
        {
            deathTimer += Time.deltaTime;
            _deathMouth.SetActive(true);
            if (deathTimer >= 3)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        sr.color = Color.Lerp(Color.clear,zeroHealthColor, 1 - (hp / 100f));
    }
    public void ChangeHP(float change)
    {
        gameObject.GetComponent<PlayerAudio>().PlayAudio(PlayerAudio.PlayerEvent.hit);
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
        return 1f;
    }

    public void setHoldingPostil(bool holding)
    {
        GetComponent<PlayerMovement>().SetHoldGun(holding);
    }

 
}
