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
        DateTime time;
        TimeSpan duration = new TimeSpan(0, 0, 2);

        public void Activate(IPlayer player, GameObject go)
        {
            Vector2 offsett = player.getDir() * player.getReach();
            go.transform.position = player.getPos() + offsett;
            time = DateTime.Now;
           
        }

        public void Deactivate(IPlayer player, GameObject go)
        {
            go.transform.position = player.getPos();
        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
            if (time.Add(duration).Date >= DateTime.Now)
            {
                Deactivate(player, go);
            }
        }
    }
}
