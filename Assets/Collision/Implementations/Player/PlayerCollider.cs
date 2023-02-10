using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : AbsColider
{
    public PlayerCollider(GameObject parent, List<AbsColider> colidingWith) : base(parent, colidingWith)
    {
    }

    public override void Accept(AbsColider other)
    {
        other.Accept(this);
    }

    override public void ColidedWith(DoorCollider doorCollider)
    {
        
        if(Input.GetKeyDown(KeyCode.E)) {
            parent.transform.position = doorCollider.leadsTo.transform.position;
        }

    }
}
