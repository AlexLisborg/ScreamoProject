using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BandageScript : ItemScript
{
    [SerializeField] float healingAmount;
    [SerializeField] float duration;
    [SerializeField] Timer timer;
    private BandageActivation ba;

    
    public override Activation getActivation()
    {
        if (ba == null)
        {
            ba = new BandageActivation(timer, destroy, healingAmount, duration);
        }
        return ba;
    }

    public override Sprite getIcon()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public class BandageActivation : Activation
    {
        private Timer timer;
        private Action selfDestruct;
        private float healingAmount;
        private float duration;
        private bool isHealing = false;
        private int activationCount = 0;
        public BandageActivation(Timer timer, Action selfDestruct, float healingAmount, float duration) {
            this.timer = timer;
            this.selfDestruct = selfDestruct;
            this.healingAmount = healingAmount;
            this.duration = duration;
        }

        public override void Activate(IPlayer player, GameObject go)
        {
            go.SetActive(true);
            activationCount++;
            timer.StartTimer(() => TryHeal(player, activationCount) , duration);
            isHealing = true;
           
        }

        private void TryHeal(IPlayer player, int activationCount)
        {
            if (isHealing && this.activationCount == activationCount)
            {
                Debug.Log("used");
                player.ChangeHP(healingAmount);
                selfDestruct();
            }
        }

        public override void Deactivate(IPlayer player, GameObject go)
        {
            go.transform.position = player.getPos();
            isHealing = false;
            go.SetActive(false);
        }

   

        public override void UpdateActivation(IPlayer player, GameObject go)
        {
            Vector2 offsett = player.getDir() * player.getReach();
            go.transform.position = player.getPos() + offsett;
        }
    }

}
