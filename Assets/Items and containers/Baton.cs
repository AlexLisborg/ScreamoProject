using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Baton : ItemScript
{
    [SerializeField] public int damage;
    [SerializeField] public float knockbackStrength;
    [SerializeField] public float staggerDuration;
    [SerializeField] public float swingDurationSec;
    [SerializeField] private Timer timer;
    [SerializeField] private float swingAngel;
    private Batonactivation batonactivation;



    public override Sprite getIcon()
    {
        return GetComponent<SpriteRenderer>().sprite;
    }

    public override Activation getActivation()
    {
        return batonactivation;
    }
    private void Awake()
    {
        batonactivation = new Batonactivation(swingDurationSec, timer, Deactivate,swingAngel); ;
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
        public Batonactivation(float swingDurationSec, Timer timer, Action<IPlayer> baseDeactivate, float swingAngel)
        {
            this.swingDurationSec = swingDurationSec;
            this.timer = timer; 
            this.baseDeactivate = baseDeactivate;
            this.swingAngel = swingAngel;
        }




        public override void Activate(IPlayer player, GameObject go)
        {

            //Do animation
            go.SetActive(true);
            timer.StartTimer( () => baseDeactivate(player), swingDurationSec);
            startingRot = (float)Math.Asin(player.getDir().x);
            yLessThan0 = 1;
            if (player.getDir().y < 0)
            {
                yLessThan0 = -1;
            }
        }

        public override void Deactivate(IPlayer player, GameObject go)
        {
            rotChange = 0;
            timer.StopTimer();
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
