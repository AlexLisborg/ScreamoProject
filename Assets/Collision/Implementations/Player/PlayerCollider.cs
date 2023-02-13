using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : AbsColider
{
    public Container containerAvilable = null;
    public PlayerCollider(GameObject parent) : base(parent)
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

    override public void EnterCollision(DoorCollider doorCollider)
    {
        
        if(Input.GetKeyDown(KeyCode.E)) {
            parent.transform.position = doorCollider.leadsTo.transform.position;
        }

    }

    override public void EnterCollision(ContainerCollider containerCollider)
    {
        if (containerAvilable == null)
        {
            containerAvilable = containerCollider.container;
        }
    }

    public override void ExitCollision(ContainerCollider containerCollider)
    {
        if(containerAvilable == containerCollider.container) {
            containerAvilable = null;
        }
    
    }




}
