using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BatonCollidable : Colidable
{
    [SerializeField]  private Baton baton;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new BatonCollider(go,StartCoroutine,baton);
    }

    public class BatonCollider : AbsColider
    {
        private Func<IEnumerator,Coroutine> startCoroutine;
        private Baton baton;
        public BatonCollider(GameObject parent, Func<IEnumerator, Coroutine> startCoroutine, Baton baton) : base(parent)
        {
            this.startCoroutine = startCoroutine;
            this.baton = baton; 
        }

        public override void AcceptEnter(AbsColider other)
        {
            other.AcceptEnter(this);
        }

        public override void AcceptExit(AbsColider other)
        {
            other.AcceptExit(this);
        }

        public override void AcceptStay(AbsColider other)
        {
            other.AcceptStay(this);
        }

        public override void EnterCollision(CharacterColider characterColider)
        {
            MeleeHit(characterColider, baton.damage, baton.knockbackStrength, baton.staggerDuration);
        }

        private void MeleeHit(CharacterColider target, int damage, float knockbackStrength, float staggerDuration)
        {
            target.damage(damage);
            Vector3 playerPos = target.getPos();
            Vector2 knockbackDirection = (target.getPos() - playerPos).normalized;

  
            target.Addforce(knockbackDirection * knockbackStrength, ForceMode2D.Impulse);

            startCoroutine(StaggerCoroutine(target, staggerDuration));
        }
        private IEnumerator StaggerCoroutine(CharacterColider target, float duration)
        {
            target.enableMovemnt(false);

            yield return new WaitForSeconds(duration);

            target.enableMovemnt(true);
        }
    }
}
