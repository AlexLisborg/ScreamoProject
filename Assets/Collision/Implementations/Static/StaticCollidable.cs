using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticColidable : Colidable
{
    private GameObject go;
    private List<AbsColider> areColidingWith;

  
    public override AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        return new StaticColider(go, areColidingWith);
    }
}
