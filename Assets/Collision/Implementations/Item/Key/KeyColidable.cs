using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyColidable : Colidable
{
    public override AbsColider GetNewColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        return new KeyCollider(go, areColidingWith);
    }
}
