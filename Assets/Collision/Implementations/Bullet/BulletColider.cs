using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletColider : AbsColider
{
    public BulletColider(GameObject parent) : base(parent)
    {
    }

    public override void AcceptEnter(AbsColider other)
    {
        
        other.EnterCollision(this);
    }
    public override void AcceptStay(AbsColider other)
    {
        other.AcceptStay(this);
    }

    public override void AcceptExit(AbsColider other)
    {
        other.AcceptExit(this);
    }




   
}
