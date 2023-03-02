using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class ItemScript : MonoBehaviour
{

    private bool activated = false;
    private bool equipt = false;
    private Action onDestroy = () => { };
    public IPlayer currentPlayer { get; private set;}


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

    public void Update()
    {
        if (activated)
        {
            getActivation().UpdateActivation(currentPlayer, gameObject);
        }
        if (equipt)
        {
            getActivation().UpdateEquiptment(currentPlayer, gameObject);
        }

    }



    public virtual void Activate(IPlayer player)
    {
        if (!activated)
        {
            activated = true;
            getActivation().Activate(player, gameObject);
        }
    }

    public void Deactivate(IPlayer player)
    {
        if (activated)
        {
            getActivation().Deactivate(player, gameObject);
            activated = false;
        }
            
    }

    public void Equipt(IPlayer player)
    {
        Debug.Log(player);
        currentPlayer = player;
        equipt = true;
        getActivation().Equipt(player, gameObject);
    }

    public void Unequipt(IPlayer player)
    {
        Debug.Log(player);
        Deactivate(player);
        getActivation().Unequipt(player, gameObject);
        equipt = false;
        gameObject.SetActive(false);
        currentPlayer = null;
    }

    public bool isActivated()
    {
        return activated;
    }

    
}

  
