using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCollidable : Colidable
{
    public ContainerCollider col = null;

    public override AbsColider GetColiderInstance(GameObject go)
    {
        if(col == null)
        {
            col = new ContainerCollider(go);
        }
        return col;
    }
}
