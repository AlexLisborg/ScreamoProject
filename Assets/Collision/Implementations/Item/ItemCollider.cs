using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : AbsColider
{
    public ItemCollider(GameObject parent, List<AbsColider> colidingWith) : base(parent, colidingWith)
    {
    }

    public override void Accept(AbsColider other)
    {
        other.Accept(this);
    }
}
