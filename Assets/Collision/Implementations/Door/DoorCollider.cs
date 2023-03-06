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
    private Vector2 spawnOffset;


    public DoorCollider(GameObject parent, DoorScript leadsToDoor, Action<KeyCollider> callOnOpen, Func<bool> isOpen, Vector2 spawnOffset) : base(parent)
    {
        leadsTo = leadsToDoor;
        this.callOnOpen = callOnOpen;
        this.isOpen = isOpen;   
        this.spawnOffset = spawnOffset;
    }

    public void goThrough(GameObject go)
    {
        if (isOpen())
        {
            leadsTo.openDoor();
            go.transform.position = leadsTo.spawnPosition();
            Debug.Log(leadsTo.spawnPosition());
        }

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
        if(!isOpen())
            callOnOpen(keyColider);
    }
}
