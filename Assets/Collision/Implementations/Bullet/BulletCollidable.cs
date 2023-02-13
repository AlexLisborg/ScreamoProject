using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColidable : Colidable
{

    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new BulletColider(go);
    }
}
