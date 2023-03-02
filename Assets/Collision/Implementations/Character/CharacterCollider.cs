using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : AbsColider
{
    private EnemyHealth enemyHealth;
    public CharacterColider(GameObject parent, EnemyHealth enemyHealth ) : base(parent)
    {
        this.enemyHealth= enemyHealth;
    }

    public Vector3 getPos()
    {
        return parent.transform.position + Vector3.zero;
    }

    public void Addforce(Vector2 v, ForceMode2D fm)
    {
        parent.GetComponent<Rigidbody2D>().AddForce(v,fm);
    }

    public void enableMovemnt(bool yes)
    {

    }
    public void damage(int amount)
    {
        enemyHealth.TakeDamage(amount);
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
