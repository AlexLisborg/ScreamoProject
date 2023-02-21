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
    public override Sprite getIcon()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Start is called before the first frame update
    private void Awake()
    {
        set(new BandageActivation(timer,destroy,healingAmount,duration));
    }
    public class BandageActivation : Activation
    {
        Timer timer;
        Action selfDestruct;
        float healingAmount;
        float duration;
        public BandageActivation(Timer timer, Action selfDestruct, float healingAmount, float duration) {
            this.timer = timer;
            this.selfDestruct = selfDestruct;
            this.healingAmount = healingAmount;
            this.duration = duration;
        }

        public void Activate(IPlayer player, GameObject go)
        {
            Vector2 offsett = new Vector2(Mathf.Cos(player.getDir()), Mathf.Sin(player.getDir())) * player.getReach();
            go.transform.position = player.getPos() + offsett;
            timer.StartTimer(() => { player.ChangeHP(healingAmount); selfDestruct(); }, duration);
           
        }

        public void Deactivate(IPlayer player, GameObject go)
        {
            go.transform.position = player.getPos();
        }

        public void UpdateActivation(IPlayer player, GameObject go)
        {
           
        }
    }

}
