using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollidable : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new BulletCollider(go, Destroy);
    }

    public class BulletCollider : AbsColider
    {
        private Action<GameObject> Destroy;
        public BulletCollider(GameObject parent, Action<GameObject> Destroy) : base(parent)
        {
            this.Destroy = Destroy;
        }

        

        public override void AnyEnterCollision(AbsColider other)
        {
            Destroy(parent);
        }

        public override void EnterCollision(CharacterColider characterColider)
        {
            characterColider.damage(100);
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
    }

}
