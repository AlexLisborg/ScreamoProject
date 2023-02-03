using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : AbsColider
{
    public override void Accept(AbsColider other)
    {
        other.ColidedWith(this);
    }

    public override void ColidedWith(CharacterColider characterColider)
    {
        //idk- kiss?
    }

    public override void ColidedWith(BulletColider bulletColider)
    {
        //Take damage
    }
}
