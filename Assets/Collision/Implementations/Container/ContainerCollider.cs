using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCollider : AbsColider
{
    private Func<Container> getContainer;
    public Container GetContainer()
    {
        return getContainer.Invoke();
    }

  
    public ContainerCollider(GameObject parent, Func<Container> getContainer) : base(parent)
    {
        this.getContainer = getContainer;   
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
