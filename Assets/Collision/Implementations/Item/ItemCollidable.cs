using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollidable : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new ItemCollider(go);
    }
}
