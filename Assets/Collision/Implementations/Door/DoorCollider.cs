using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorCollider : AbsColider
{

    public DoorScript leadsTo;

    public void set(DoorScript leadsToDoor)
    {
        leadsTo = leadsToDoor;
    }
    public DoorCollider(GameObject parent, List<AbsColider> colidingWith) : base(parent, colidingWith)
    {
    }

    public override void Accept(AbsColider other)
    {
        other.Accept(this);
    }

    
}
