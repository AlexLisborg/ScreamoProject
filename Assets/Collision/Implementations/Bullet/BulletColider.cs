using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColider : AbsColider
{
    public BulletColider(GameObject parent, List<AbsColider> colidingWith) : base(parent, colidingWith)
    {
    }

    public override void Accept(AbsColider other)
    {
        
        other.ColidedWith(this);
    }


    public new void ColidedWith(CharacterColider wallColider)
    {
       
        //Bullet dies
        throw new System.NotImplementedException();
    }

    public new void ColidedWith(BulletColider bulletColider)
    {
        //BOOOM
        throw new System.NotImplementedException();
    }

    public new void ColidedWith(StaticColider bulletColider)
    {
        //Bullet dies
        throw new System.NotImplementedException();
    }
}
