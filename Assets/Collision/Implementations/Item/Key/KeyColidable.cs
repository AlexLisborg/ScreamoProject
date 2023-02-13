using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyColidable : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new KeyCollider(go);
    }
}
