using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovCollidable : Colidable
{
    private Action<GameObject> onBlocked = (o) => { };
    Action<GameObject> onFreed = (o) => { };
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new FovCollider(go, () => onBlocked(gameObject), () => onFreed(gameObject));
    }
    public void setOnBlocked(Action<GameObject> onBlocked, Action<GameObject> onFreed)
    {
        this.onBlocked = onBlocked;
        this.onFreed = onFreed;
    }

    public class FovCollider : AbsColider
    {
        private Action onBlocked;
        private Action onFreed;

 

        public FovCollider(GameObject parent, Action onBlocked, Action onFreed) : base(parent)
        {
            this.onBlocked = onBlocked;
            this.onFreed = onFreed;
        }

        public override void EnterCollision(WallCollidable.WallCollider wall)
        {
            onBlocked();
        }

        public override void ExitCollision(WallCollidable.WallCollider wall)
        {
            onFreed();
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
