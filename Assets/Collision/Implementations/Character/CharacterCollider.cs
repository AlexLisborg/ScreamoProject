using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : AbsColider
{
    public CharacterColider(GameObject parent, List<AbsColider> colidingWith) : base(parent, colidingWith)
    {
    }

    public override void Accept(AbsColider other)
    {
        other.ColidedWith(this);
    }


    public new void ColidedWith(CharacterColider characterColider)
    {
        //idk- kiss?
        throw new System.NotImplementedException();
    }

    public new void ColidedWith(BulletColider bulletColider)
    {
        //Take damage
        throw new System.NotImplementedException();
    }

    public new void ColidedWith(StaticColider bulletColider)
    {
        //Do not go through lol- hit head?
        throw new System.NotImplementedException();
    }
}
