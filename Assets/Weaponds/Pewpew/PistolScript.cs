using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InputManagerScript;
using static PistolAudio;

public class PistolScript : OneShotItem
{
    //[SerializeField] public InputManagerScript InputManager { get; set; }
    [SerializeField] private Timer timer;
    [SerializeField] private float reloadTimeSec;
    private List<BulletScript> bullets = new List<BulletScript>();
    public AudioSource source;

    public void setBullets(List<BulletScript> bullets)
    {
        this.bullets = bullets; 
        
    }

    public override Activation getActivation()
    {
<<<<<<< Updated upstream
        return new PistolActivation(bullets, Instantiate, timer, reloadTimeSec);
=======
        return new PistolActivation(bullets, source);
>>>>>>> Stashed changes
    }

    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public class PistolActivation : Activation
    {
        //private InputManagerScript im;
        private List<BulletScript> bullets;
        private AudioSource source;
        //private Action inputActionDeactivate = null;
<<<<<<< Updated upstream
        private bool isreloading = false;
        private Timer timer;
        private float reloadTimeSec;
        public PistolActivation( List<BulletScript> bullets, Func<GameObject, GameObject> Instantiate, Timer timer, float reloadTimeSec)
        {
            this.bullets = bullets;
            this.timer = timer;
            this.reloadTimeSec = reloadTimeSec;
=======
        public PistolActivation( List<BulletScript> bullets, AudioSource source)
        {
            this.bullets = bullets; 
            this.source = source;
            if (source == null)
            {
                Debug.Log("Source is null1");
            }
>>>>>>> Stashed changes
        }



        public override void Activate(IPlayer player, GameObject go)
        {
            if (bullets.Count > 0)
            {
                source.Play();
                GameObject.Find("Pistol(Clone)").GetComponent<PistolAudio>().PlayAudio(PistolEvent.shoot);
                bullets[0].shoot(player);
                
                bullets.RemoveAt(0);
                Debug.Log(bullets.Count + " bullets left");
            }
            else
            {
                GameObject.Find("Pistol(Clone)").GetComponent<PistolAudio>().PlayAudio(PistolEvent.outOfAmmo);
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
            player.setHoldingPostil(true);
            go.SetActive(true);
        }

        public override void Unequipt(IPlayer player, GameObject go)
        {
            player.setHoldingPostil(false);
        }
    }
}
