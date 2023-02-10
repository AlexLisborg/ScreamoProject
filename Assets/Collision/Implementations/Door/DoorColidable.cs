using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColidable : Colidable
{
    public DoorCollider col = null;
    public override AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        if(col == null) { 
            col = new DoorCollider(go, areColidingWith); 
        }
        return col;
    }

   
}
