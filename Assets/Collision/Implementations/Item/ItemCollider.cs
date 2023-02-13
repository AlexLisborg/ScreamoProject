using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : AbsColider
{
    public ItemCollider(GameObject parent) : base(parent)
    {
    }

    public override void AcceptEnter(AbsColider other)
    {
        other.AcceptEnter(this);
    }
    public override void AcceptStay(AbsColider other)
    {
        other.AcceptStay(this);
    }

    public override void AcceptExit(AbsColider other)
    {
        other.AcceptExit(this);
    }
}
