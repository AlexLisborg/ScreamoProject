using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollider : AbsColider
{

    public KeyCollider(GameObject parent) : base(parent)
    {

    }

    public void destroyKey()
    {
        parent.GetComponent<KeyScript>().destroy();
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
