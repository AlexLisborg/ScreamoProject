using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baton : ItemScript
{
    public int damage = 30;
    public float knockbackStrength = 0.000f;
    public float staggerDuration = 0.5f;



    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public override Activation getActivation()
    {
        return new Batonactivation();
    }
    public class Batonactivation : Activation
    {


        public void Activate(IPlayer player, GameObject go)
        {
            
         
        }

        public void Deactivate(IPlayer player, GameObject go)
        {
            ;
        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
            Vector2 offsett = new Vector2(Mathf.Cos(player.getDir()), Mathf.Sin(player.getDir())) * player.getReach();
            go.transform.position = player.getPos() + offsett;
        }
    }
}
