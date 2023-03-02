using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class ItemScript : MonoBehaviour
{

    private bool activated = false;
    public IPlayer currentPlayer { get; private set; }
    private Action onDestroy = () => { };



    public abstract Sprite getIcon();
    public abstract Activation getActivation();
   

    public void setOnDestroy(Action onDestroy)
    {
        this.onDestroy = onDestroy; 
    }

    public void destroy()
    {
        Debug.Log("Destroy item");
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
            getActivation().UpdateActivation(currentPlayer, gameObject);
        }

    }



    public virtual void Activate()
    {
        if (!activated)
        {

            activated = true;
            getActivation().Activate(currentPlayer, gameObject);
        }
    }

    public void Deactivate()
    {
        if (activated)
        {
            getActivation().Deactivate(currentPlayer, gameObject);
            activated = false;
        }
            
    }

    public void Equipt(IPlayer player)
    {
        currentPlayer = player;
        getActivation().Equipt(player, gameObject);
    }

    public void Unequipt()
    {
        Deactivate();
        getActivation().Unequipt(currentPlayer, gameObject);
        currentPlayer = null;
        gameObject.SetActive(false);
    }

    public bool isActivated()
    {
        return activated;
    }

    
}

  
