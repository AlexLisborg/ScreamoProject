using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Colider for static undestructable stuff, such as walls
//All methodes should be empty as nothing should change to the object
public class StaticColider : AbsColider
{
    public override void Accept(AbsColider other)
    {

    }

    public override bool CallOnStay()
    {
        return false;
    }

    public override void ColidedWith(CharacterColider wallColider)
    {
    }

    public override void ColidedWith(BulletColider bulletColider)
    {
    }

    public override void ColidedWith(StaticColider bulletColider)
    {
    }
}
