using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollidable : Colidable
{
    [SerializeField] private PlayerScript player;
    public PlayerCollider col = null;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        if (col == null)
            col = new PlayerCollider(go,player);

        return col;
    }

 

}
