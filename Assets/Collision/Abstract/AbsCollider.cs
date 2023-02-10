using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class AbsColider 
{
    protected readonly GameObject parent;
    private List<AbsColider> colidingWith = new List<AbsColider>();
    
    public AbsColider(GameObject parent, List<AbsColider> colidingWith)
    {
        this.parent = parent;
        this.colidingWith = colidingWith;

    }
 

    abstract public void Accept(AbsColider other);

    //Add new method with argumnet of new subtype
    //These methodes are for when this oject colides with another spesifict oject
    //By default then a collsion will do nothing unless the method is overwritten
    public virtual void ColidedWith(CharacterColider wallColider) { }
    public virtual void ColidedWith(BulletColider bulletColider) { }
    public virtual void ColidedWith(StaticColider bulletColider) { }
    public virtual void ColidedWith(KeyCollider keyColider) { }

    public virtual void ColidedWith(DoorCollider doorColider) { }

    public virtual void ColidedWith(PlayerCollider keyColider) { }

}
