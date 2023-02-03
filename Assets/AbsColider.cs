using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsColider 
{
    public GameObject parent;
    public void setParent(GameObject parent)
    {
        this.parent = parent;
    }
    abstract public void Accept(AbsColider other);

    abstract public void ColidedWith(CharacterColider wallColider);
    abstract public void ColidedWith(BulletColider bulletColider);

    abstract public void ColidedWith(Colid bulletColider);

}
