using UnityEngine;

public abstract class AbsColider 
{
    protected readonly GameObject parent;
    
    public AbsColider(GameObject parent)
    {
        this.parent = parent;
    }
 

    abstract public void AcceptEnter(AbsColider other);

    abstract public void AcceptStay(AbsColider other);

    abstract public void AcceptExit(AbsColider other);

    public virtual void AnyEnterCollision(AbsColider other) { }
    public virtual void AnyStayCollision(AbsColider other) { }

    public virtual void AnyExitCollision(AbsColider other) { }

    //Add new method with argumnet of new subtype
    //These methodes are for when this oject collides with another spesifict oject
    //By default then a collsion will do nothing unless the method is overwritten
    public virtual void EnterCollision(CharacterColider wallColider) { }
    public virtual void StayCollision(CharacterColider wallColider) { }
    public virtual void ExitCollision(CharacterColider wallColider) { }


    public virtual void EnterCollision(StaticColider bulletColider) { }
    public virtual void StayCollision(StaticColider bulletColider) { }
    public virtual void ExitCollision(StaticColider bulletColider) { }


    public virtual void EnterCollision(KeyCollider keyColider) { }
    public virtual void StayCollision(KeyCollider keyColider) { }
    public virtual void ExitCollision(KeyCollider keyColider) { }


    public virtual void EnterCollision(DoorCollider doorColider) { }
    public virtual void StayCollision(DoorCollider doorColider) { }
    public virtual void ExitCollision(DoorCollider doorColider) { }


    public virtual void EnterCollision(PlayerCollider keyColider) { }
    public virtual void StayCollision(PlayerCollider keyColider) { }
    public virtual void ExitCollision(PlayerCollider keyColider) { }

    public virtual void EnterCollision(ContainerCollider containerCollider) { }
    public virtual void StayCollision(ContainerCollider containerCollider) { }
    public virtual void ExitCollision(ContainerCollider containerCollider) { }

    public virtual void EnterCollision(BatonCollidable.BatonCollider baton) { }
    public virtual void StayCollision(BatonCollidable.BatonCollider baton) { }
    public virtual void ExitCollision(BatonCollidable.BatonCollider baton) { }

    public virtual void EnterCollision(WallCollidable.WallCollider wall) { }
    public virtual void StayCollision(WallCollidable.WallCollider wall) { }
    public virtual void ExitCollision(WallCollidable.WallCollider wall) { }

    public virtual void EnterCollision(FovCollidable.FovCollider fovElement) { }
    public virtual void StayCollision(FovCollidable.FovCollider fovElement) { }
    public virtual void ExitCollision(FovCollidable.FovCollider fovElement) { }



}
