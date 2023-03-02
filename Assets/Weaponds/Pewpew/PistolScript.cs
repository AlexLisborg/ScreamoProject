using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManagerScript;

public class PistolScript : OneShotItem
{
    //[SerializeField] public InputManagerScript InputManager { get; set; }
    [SerializeField] private Timer timer;
    [SerializeField] private float reloadTimeSec;
    private List<BulletScript> bullets = new List<BulletScript>();



    public void setBullets(List<BulletScript> bullets)
    {
        this.bullets = bullets; 
        
    }

    public override Activation getActivation()
    {
        return new PistolActivation(bullets, Instantiate, timer, reloadTimeSec);
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
        private bool isreloading = false;
        private Timer timer;
        private float reloadTimeSec;
        public PistolActivation( List<BulletScript> bullets, Func<GameObject, GameObject> Instantiate, Timer timer, float reloadTimeSec)
        {
            this.bullets = bullets;
            this.timer = timer;
            this.reloadTimeSec = reloadTimeSec;
        }



        public override void Activate(IPlayer player, GameObject go)
        {
            if (bullets.Count > 0)
            {
                bullets[0].shoot(player);
                
                bullets.RemoveAt(0);
                Debug.Log(bullets.Count + " bullets left");
            }
        }


        public override void UpdateEquiptment(IPlayer player, GameObject go)
        {
       
            if (Input.GetKeyDown(KeyCode.R) && !isreloading) {
     
                    
                isreloading = true;
                timer.StartTimer(() => {
                    List<BulletScript> bulletsInInventory = player.getInventory().getAllItemsOf<BulletScript>();
                    if (bulletsInInventory.Count > 0)
                    {
                        BulletScript bullet = bulletsInInventory[0];
                        player.getInventory().GetInventory().removeItem(bullet);
                        bullets.Add(bullet);
                    }
                    isreloading = false;
                }, reloadTimeSec);
              
                
            }

          
        }


        public override void Equipt(IPlayer player, GameObject go)
        {
            Debug.Log("equipped");
            player.setHoldingPostil(true);
            go.SetActive(true);
        }

        public override void Unequipt(IPlayer player, GameObject go)
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
