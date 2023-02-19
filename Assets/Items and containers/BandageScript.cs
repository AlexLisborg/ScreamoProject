using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BandageScript : ItemScript
{
    
    public override Sprite getIcon()
    {



        return gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        set(new BandageActivation());
    }
    public class BandageActivation : Activation
    {
        DateTime time;
        TimeSpan duration = new TimeSpan(0, 0, 2);

        public void Activate(IPlayer player, GameObject go)
        {
            Vector2 offsett = new Vector2(Mathf.Cos(player.getDir()), Mathf.Sin(player.getDir())) * player.getReach();
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
                player.ChangeHP(50);
                Deactivate(player, go);
            }
        }
    }

}
