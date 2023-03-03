using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : AbsColider
{
    private EnemyHealth enemyHealth;
    private Rigidbody2D body;
    private EnemyMovement enemyMovement;
    private Timer timer;
    public CharacterColider(GameObject parent, EnemyHealth enemyHealth, Rigidbody2D body, EnemyMovement enemyMovement, Timer timer) : base(parent)
    {
        this.enemyHealth = enemyHealth;
        this.body = body;
        this.enemyMovement = enemyMovement;
        this.timer = timer;
    }


    public Vector3 getPos()
    {
        return parent.transform.position + Vector3.zero;
    }

    public void Addforce(Vector2 v, ForceMode2D fm)
    {
        body.AddForce(v,fm);
    }

    public void disableMovment(float durationSec)
    {
        enemyMovement.enabled = false;
        timer.StopTimer();
        timer.StartTimer(() => { enemyMovement.enabled = true; }, durationSec);
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
