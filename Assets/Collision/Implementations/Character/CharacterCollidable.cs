using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Colidable
{
    public override AbsColider GetNewColiderInstance(GameObject go, List<AbsColider> areColidingWith)
    {
        return new CharacterColider(go, areColidingWith);
    }
}
