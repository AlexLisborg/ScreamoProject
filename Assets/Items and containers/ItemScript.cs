using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ItemScript : MonoBehaviour
{


 

    public abstract void Activate()
    {
        if (!activated)
        {
            activated = true;
            activations.Activate(player, gameObject, this);
        }
    }

    public void Deactivate()
    {
        if (activated)
        {
            deactivation.Deactivate(player, gameObject);
            activated = false;
        }
            
    }

    public void SimpleDeactivate()
    {
        Deactivate();
    }
}

  
