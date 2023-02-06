using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColidable : Colidable
{
    public override AbsColider GetNewColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        return new DoorCollider(go, areColidingWith);
    }
}
