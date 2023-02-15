using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidable : Colidable
{
    public PlayerCollider col = null;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        if (col == null)
            col = new PlayerCollider(go);

        return col;
    }

 

}
