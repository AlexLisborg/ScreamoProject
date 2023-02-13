using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorCollider : AbsColider
{

    public DoorScript leadsTo;

    public DoorCollider(GameObject parent, DoorScript leadsToDoor) : base(parent)
    {
        leadsTo = leadsToDoor;
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
