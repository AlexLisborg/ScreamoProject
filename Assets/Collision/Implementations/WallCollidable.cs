using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollidable : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new WallCollider(go);    
    }

    public class WallCollider : AbsColider
    {
        public WallCollider(GameObject parent) : base(parent)
        {
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
    }
}
