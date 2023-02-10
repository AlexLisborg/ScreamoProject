using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollidable : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        return new ItemCollider(go, areColidingWith);
    }
}
