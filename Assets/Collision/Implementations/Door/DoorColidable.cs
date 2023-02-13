using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorColidable : Colidable
{
    [SerializeField] DoorScript leadsTo;
    public DoorCollider col = null;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        if(col == null) { 
            col = new DoorCollider(go,leadsTo); 
        }
        return col;
    }

   
}
