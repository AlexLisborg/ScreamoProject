using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BatonCollidable : Colidable
{
    [SerializeField]  private Baton baton;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new BatonCollider(go,baton);
    }

    public class BatonCollider : AbsColider
    {
        private Baton baton;
        public BatonCollider(GameObject parent, Baton baton) : base(parent)
        {
            this.baton = baton; 
        }

        public override void AcceptEnter(AbsColider other)
        {
            other.EnterCollision(this);
        }

        public override void AcceptExit(AbsColider other)
        {
            other.ExitCollision(this);
        }

        public override void AcceptStay(AbsColider other)
        {
            other.StayCollision(this);
        }

        public override void EnterCollision(CharacterColider characterColider)
        {
            Debug.Log("hit emeny");
            GameObject.Find("BatonItem(Clone)").GetComponent<BatonAudio>().PlayAudio(BatonAudio.BatonEvent.hit);
            MeleeHit(characterColider, baton.damage, baton.knockbackStrength, baton.staggerDuration );
        }

        private void MeleeHit(CharacterColider target, int damage, float knockbackStrength, float staggerDuration)
        {
            target.damage(damage);
            Vector3 playerPos = baton.currentPlayer.getPos();
            Vector2 knockbackDirection = (target.getPos() - playerPos).normalized;

  
            target.Addforce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse);

            target.disableMovment(staggerDuration);
            
        }

    }
}
