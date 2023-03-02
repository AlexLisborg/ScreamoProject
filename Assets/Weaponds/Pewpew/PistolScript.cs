using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManagerScript;

public class PistolScript : OneShotItem
{
    //[SerializeField] public InputManagerScript InputManager { get; set; }
    private List<BulletScript> bullets = new List<BulletScript>();



    public void setBullets(List<BulletScript> bullets)
    {
        this.bullets = bullets; 
    }

    public override Activation getActivation()
    {
        return new PistolActivation(bullets);
    }

    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public class PistolActivation : Activation
    {
        //private InputManagerScript im;
        private List<BulletScript> bullets;
        //private Action inputActionDeactivate = null;
        public PistolActivation( List<BulletScript> bullets)
        {
            this.bullets = bullets; 
        }

        public void Activate(IPlayer player, GameObject go)
        {
            if (bullets.Count > 0)
            {
                bullets[0].shoot(player);
                //bullets.RemoveAt(0);
            }
        }

        public void Deactivate(IPlayer player, GameObject go)
        {
        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
            if (Input.GetKeyDown(KeyCode.R)) { }
        }

        public void Equipt(IPlayer player, GameObject go)
        {
            Debug.Log("equipped");
            player.setHoldingPostil(true);
        }

        public void Unequipt(IPlayer player, GameObject go)
        {
            player.setHoldingPostil(false);
        }
    }

    // Checks if audio script is null before playing audio
    private void PlayAudio(PistolAudio.PistolEvent pistolEvent)
    {
        if (gameObject.GetComponent<PistolAudio>() != null)
        {
            gameObject.GetComponent<PistolAudio>().PlayAudio(pistolEvent);
        }
        else
        {
            Debug.Log("Scritp was null");
        }
    }
}
