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
        batonactivation = new Batonactivation(swingDurationSec, timer, Deactivate); ;
    }
    public class Batonactivation : Activation
    {
        private float swingDurationSec;
        private Timer timer;
        private bool swinging = false;
        private float rotChange = 0;
        private Action baseDeactivate;
        public Batonactivation(float swingDurationSec, Timer timer, Action baseDeactivate)
        {
            this.swingDurationSec = swingDurationSec;
            this.timer = timer; 
            this.baseDeactivate = baseDeactivate;
        }


        public void Activate(IPlayer player, GameObject go)
        {
            go.SetActive(true);
            swinging = true;
            timer.StartTimer( baseDeactivate, swingDurationSec);
            
        }

        public void Deactivate(IPlayer player, GameObject go)
        {
            swinging = false;
            rotChange = 0;
            timer.StopTimer();
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
            rotChange += 180 * Time.deltaTime / swingDurationSec;
            Vector3 rotvecot = new Vector3(Mathf.Sin(Mathf.Deg2Rad * rotChange), Mathf.Cos(Mathf.Deg2Rad * rotChange),0);

            Vector2 offsett = Vector3.Normalize(player.getDir() + rotvecot) * player.getReach();
            go.transform.position = player.getPos() + offsett;


            Vector3 rot;

 
            
            
            if (player.getDir().x < 0)
            {
                rot = new Vector3(0, 0, Vector3.Angle(player.getDir(), new Vector3(0, 1, 0)));
            }
            else
            {
                rot = new Vector3(0, 0, -Vector3.Angle(player.getDir(), new Vector3(0, 1, 0)));
            }


            go.transform.eulerAngles = rot + new Vector3(0,0,45);
        }
    }
}
