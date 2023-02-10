using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColidable : Colidable
{

    public override AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        return new BulletColider(go, areColidingWith);
    }
}
