using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManagerScript;

public class PistolScript : ItemScript
{
    //[SerializeField] public InputManagerScript InputManager { get; set; }
    private List<BulletScript> bullets = new List<BulletScript>();

    private Func<bool> canShoot;

    public void setCanShoot(Func<bool> canShoot)
    {
        this.canShoot = canShoot;
    }

    public void setBullets(List<BulletScript> bullets)
    {
        this.bullets = bullets; 
    }

    public override Activation getActivation()
    {
        return new PistolActivation(() => canShoot(), bullets);
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
        private Func<bool> canShoot;
        public PistolActivation(Func<bool> canShoot, List<BulletScript> bullets)
        {
            this.canShoot= canShoot;
            this.bullets = bullets; 
        }

        private void shoot(IPlayer player)
        {
            if(bullets.Count > 0)
            {
                bullets[0].shoot(player);
                bullets.RemoveAt(0);
            }
            
        }
        public void Activate(IPlayer player, GameObject go)
        {
            Debug.Log("here");
            player.setHoldingPostil(true);
            //inputActionDeactivate = im.addAction(1, KeyCode.Mouse0,KeyEvent.KeyDown, () => shoot(player));

        }

        public void Deactivate(IPlayer player, GameObject go)
        {
            player.setHoldingPostil(false);
            //if (inputActionDeactivate != null)
               // inputActionDeactivate();
        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0) && canShoot())
            {
                shoot(player);
            }
            if (Input.GetKeyDown(KeyCode.R)) { }

        }

        
    }
}
