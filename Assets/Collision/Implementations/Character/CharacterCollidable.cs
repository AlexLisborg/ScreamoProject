using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new CharacterColider(go);
    }
}
