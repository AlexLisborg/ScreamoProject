using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class ItemScript : MonoBehaviour
{
    private Activation itemActivation;
    private bool activated = false;
    private IPlayer currentPlayer;


    public abstract Sprite getIcon();
    public void set(Activation itemActivation)
    {
        this.itemActivation = itemActivation;
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
        }
            
    }

    public bool isActivated()
    {
        return activated;
    }

    
}

  
