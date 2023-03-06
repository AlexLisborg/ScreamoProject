using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyScript : ItemScript
{
    private KeyActivation keyActivation;
    public override Activation getActivation()
    {
        if(keyActivation == null)
        {
            keyActivation = new KeyActivation();
        }
        return new KeyActivation();
    }

    public override Sprite getIcon()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    

    public class KeyActivation : Activation
    {

        public override void Activate(IPlayer player, GameObject go)
        {

            go.SetActive(true);
        }

        public override void Deactivate(IPlayer player, GameObject go)
        {
            go.SetActive(false);
        }

    

        public override void UpdateActivation(IPlayer player, GameObject go)
        {
            Vector2 offsett = player.getDir() * player.getReach();
            go.transform.position = player.getPos() + offsett;
        }
    }
}
