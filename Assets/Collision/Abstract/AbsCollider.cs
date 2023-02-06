using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public abstract class AbsColider 
{
    public readonly GameObject parent;
    private List<AbsColider> colidingWith = new List<AbsColider>();
    
    public AbsColider(GameObject parent, List<AbsColider> colidingWith)
    {
        this.parent = parent;
        this.colidingWith = colidingWith;
    }


    public bool IsColidingWIth(AbsColider colider)
    {
        return colidingWith.Contains(colider);
    }

    abstract public void Accept(AbsColider other);

    //Add new method with argumnet of new subtype
    //These methodes are for when this oject colides with another spesifict oject
    //By default then a collsion will do nothing unless the method is overwritten
    public void ColidedWith(CharacterColider wallColider) { }
    public void ColidedWith(BulletColider bulletColider) { }
    public void ColidedWith(StaticColider bulletColider) { }
    public void ColidedWith(KeyCollider keyColider) { }

    public void ColidedWith(DoorCollider keyColider) { }

}
