using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : AbsColider
{
    private Container containerAvilable = null;

    public Container GetContainerAvilabe()
    {
        return containerAvilable;
    }
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

    override public void StayCollision(DoorCollider doorCollider)
    {
        if(Input.GetKey(KeyCode.E)) {
            doorCollider.goThrough(parent);
        }

    }

    override public void EnterCollision(ContainerCollider containerCollider)
    {
        if (containerAvilable == null)
        {
            
            containerAvilable = containerCollider.GetContainer();
        }

    }

    public override void ExitCollision(ContainerCollider containerCollider)
    {
        if(containerAvilable == containerCollider.GetContainer()) {
            containerAvilable.close();
            parent.GetComponent<Inventory>().GetInventory().close();
            containerAvilable = null;
        }
    
    }




}
