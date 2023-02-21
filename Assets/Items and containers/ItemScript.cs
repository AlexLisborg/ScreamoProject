using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class ItemScript : MonoBehaviour
{
    private Activation itemActivation;
    private bool activated = false;
    private IPlayer currentPlayer;
    private Action onDestroy;



    public abstract Sprite getIcon();
    public void set(Activation itemActivation)
    {
        this.itemActivation = itemActivation;
    }

    public void setOnDestroy(Action onDestroy)
    {
        this.onDestroy = onDestroy; 
    }

    public void destroy()
    {
        onDestroy();
        Destroy(gameObject);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(activated)
        {
            itemActivation.UpdateActivation(currentPlayer, gameObject);
        }
    }



    public void Activate(IPlayer player)
    {
        if (!activated)
        {
            activated = true;
            gameObject.SetActive(true);
            currentPlayer = player;
            itemActivation.Activate(player, gameObject);
        }
    }

    public void Deactivate()
    {
        if (activated)
        {
            itemActivation.Deactivate(currentPlayer, gameObject);
            currentPlayer = null;
            activated = false;
            gameObject.SetActive(false);
        }
            
    }

    public bool isActivated()
    {
        return activated;
    }

    
}

  
