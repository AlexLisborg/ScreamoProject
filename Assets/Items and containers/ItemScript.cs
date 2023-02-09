using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private Activation itemActivation;
    private bool activated = false;
    private IPlayer currentPlayer;

    public void Reset(Activation itemActivation)
    {
        itemActivation = itemActivation;
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

    
}

  
