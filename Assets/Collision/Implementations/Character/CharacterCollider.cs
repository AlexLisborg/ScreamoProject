using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : AbsColider
{
    public CharacterColider(GameObject parent) : base(parent)
    {
    }

    public void damage(float amount)
    {

    }

    public override void AcceptEnter(AbsColider other)
    {
        other.EnterCollision(this);
    }
    public override void AcceptStay(AbsColider other)
    {
        other.StayCollision(this);
    }

    public override void AcceptExit(AbsColider other)
    {
        other.ExitCollision(this);
    }
}
