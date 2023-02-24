using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorCollider : AbsColider
{

    private DoorScript leadsTo;
    private Action<KeyCollider> callOnOpen;
    private Func<bool> isOpen;

    public void goThrough(GameObject go)
    {
        if (isOpen())
        {
            leadsTo.openDoor();
            go.transform.position = leadsTo.transform.position + Vector3.zero;
        }
            
    }


    public DoorCollider(GameObject parent, DoorScript leadsToDoor, Action<KeyCollider> callOnOpen, Func<bool> isOpen) : base(parent)
    {
        leadsTo = leadsToDoor;
        this.callOnOpen = callOnOpen;
        this.isOpen = isOpen;   
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

    public override void EnterCollision(KeyCollider keyColider)
    {

        callOnOpen(keyColider);
    }
}
