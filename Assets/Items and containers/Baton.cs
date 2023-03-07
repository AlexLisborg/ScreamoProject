using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BatonAudio;

public class Baton : ItemScript
{
    [SerializeField] public int damage;
    [SerializeField] public float knockbackStrength;
    [SerializeField] public float staggerDuration;
    [SerializeField] public float swingDurationSec;
    [SerializeField] private float swingAngel;
    [SerializeField] private float coolDownTimeSec;
    [SerializeField] private GameObject Timer;
    private Batonactivation batonactivation;



    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public override Activation getActivation()
    {
        if ( batonactivation == null )
        {
            batonactivation = new Batonactivation(swingDurationSec, Instantiate(Timer).GetComponent<Timer>(), Deactivate, swingAngel, coolDownTimeSec);
        }
        return batonactivation;
    }



    public class Batonactivation : Activation
    {
        private float swingDurationSec;
        private Timer timer;
        private float rotChange = 0;
        private Action<IPlayer> baseDeactivate;
        private float startingRot = 0;
        private int yLessThan0 = 0;
        private float swingAngel;
        private int timerId;
        private float coolDownTimeSec;
        private bool onCoolDown = false;
        public Batonactivation(float swingDurationSec, Timer timer, Action<IPlayer> baseDeactivate, float swingAngel, float coolDownTimeSec)
        {
            this.swingDurationSec = swingDurationSec;
            this.timer = timer; 
            this.baseDeactivate = baseDeactivate;
            this.swingAngel = swingAngel;
            this.coolDownTimeSec = coolDownTimeSec;
        }




        public override void Activate(IPlayer player, GameObject go)
        {
            if (!onCoolDown)
            {
                //Do animation

                
                go.SetActive(true);
                go.GetComponent<BatonAudio>().PlayAudio(BatonEvent.swing);
                timerId = timer.StartTimer(() => baseDeactivate(player), swingDurationSec);
                startingRot = (float)Math.Asin(player.getDir().x);
                yLessThan0 = 1;
                if (player.getDir().y < 0)
                {
                    yLessThan0 = -1;
                }

                onCoolDown = true;
                timer.StartTimer(() => { onCoolDown = false; Debug.Log("Done"); }, coolDownTimeSec);
            }
            else
            {
                baseDeactivate(player);
            }
        }

        public override void Deactivate(IPlayer player, GameObject go)
        {
           
            rotChange = 0;
            if(!onCoolDown){
                timer.StopTimer(timerId);
            }
            go.SetActive(false);
        }



        public override void UpdateActivation(IPlayer player, GameObject go)
        {
            
            rotChange += yLessThan0 * swingAngel * Time.deltaTime / swingDurationSec;


            float currentRot =  startingRot + Mathf.Deg2Rad * (rotChange - (swingAngel/2) * yLessThan0);
            Vector3 rotvecot = new Vector3(Mathf.Sin(currentRot), Mathf.Cos(currentRot),0);
            rotvecot.y = rotvecot.y * yLessThan0;
            Vector2 offsett = Vector3.Normalize(rotvecot) * player.getReach();
            go.transform.position = player.getPos() + offsett;


            Vector3 rot = new Vector3(0, 0, -yLessThan0 * currentRot);
            if (yLessThan0 == -1)
            {
                rot.z += 135;
            }
                

            go.transform.eulerAngles = Mathf.Rad2Deg * rot + new Vector3(0,0,45);
        }
    }
}
