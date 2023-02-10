using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidable : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
       return new PlayerCollider(go, areColidingWith);
    }

 

}
