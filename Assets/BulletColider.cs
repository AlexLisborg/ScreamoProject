using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColider : AbsColider
{
    public override void Accept(AbsColider other)
    {
        other.ColidedWith(this);
    }

    public override void ColidedWith(CharacterColider wallColider)
    {
        //Bullet dies
    }

    public override void ColidedWith(BulletColider bulletColider)
    {
        //BOOOM
    }
}
