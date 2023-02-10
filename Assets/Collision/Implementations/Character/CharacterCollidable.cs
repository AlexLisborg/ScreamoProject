using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Colidable
{
    public override AbsColider GetColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        return new CharacterColider(go, areColidingWith);
    }
}
