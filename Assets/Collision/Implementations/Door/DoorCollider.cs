using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : AbsColider
{
    public DoorCollider(GameObject parent, List<AbsColider> colidingWith) : base(parent, colidingWith)
    {
    }

    public override void Accept(AbsColider other)
    {
        other.Accept(this);
    }
}
