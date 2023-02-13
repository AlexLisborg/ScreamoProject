using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidable : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go)
    {
       return new PlayerCollider(go);
    }

 

}
