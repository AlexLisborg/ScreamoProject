using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : AbsColider
{
    public CharacterColider(GameObject parent) : base(parent)
    {
    }

    public Vector3 getPos()
    {
        return parent.transform.position + Vector3.zero;
    }

    public void Addforce(Vector2 v, ForceMode2D fm)
    {
        parent.GetComponent<Rigidbody2D>().AddForce(v,fm);
    }

    public void enableMovemnt(bool yes)
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
