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



        public override void EnterCollision(DoorCollider doorColider)
        {
            Destroy(parent);
        }

        public override void ExitCollision(CharacterColider wallColider)
        {
            Destroy(parent);
        }

        public override void EnterCollision(WallCollidable.WallCollider wall)
        {
            
            Destroy(parent);
        }

        public override void EnterCollision(CharacterColider characterColider)
        {
            Debug.Log("hit");
            characterColider.damage(100);
        }

        public override void AcceptEnter(AbsColider other)
        {
           
        }

        public override void AcceptExit(AbsColider other)
        {
           
        }

        public override void AcceptStay(AbsColider other)
        {
            
        }
    }

}
