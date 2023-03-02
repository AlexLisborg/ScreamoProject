using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : ItemScript
{
    public override Activation getActivation()
    {
        return new KeyActivation();
    }

    public override Sprite getIcon()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    

    public class KeyActivation : Activation
    {

        public void Activate(IPlayer player, GameObject go)
        {

            go.SetActive(true);
        }

        public void Deactivate(IPlayer player, GameObject go)
        {
            go.SetActive(false);
        }

        public void Equipt(IPlayer player, GameObject go)
        {

        }

        public void Unequipt(IPlayer player, GameObject go)
        {

        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
            Vector2 offsett = player.getDir() * player.getReach();
            go.transform.position = player.getPos() + offsett;
        }
    }
}
