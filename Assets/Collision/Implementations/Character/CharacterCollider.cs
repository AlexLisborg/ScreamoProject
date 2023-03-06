using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColider : AbsColider
{
    private EnemyHealth enemyHealth;
    private Rigidbody2D body;
    private EnemyMovement enemyMovement;
    private SpriteRenderer spriteRenderer;
    private Timer timer;
    private bool canHitPlayer = true;
    public CharacterColider(GameObject parent, EnemyHealth enemyHealth, Rigidbody2D body, EnemyMovement enemyMovement, Timer timer, SpriteRenderer spriteRenderer) : base(parent)
    {
        this.enemyHealth = enemyHealth;
        this.body = body;
        this.enemyMovement = enemyMovement;
        this.timer = timer;
        this.spriteRenderer = spriteRenderer;
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
        timer.StartTimer(() => { enemyMovement.enabled = true; }, durationSec);
    }
    public void damage(int amount)
    {
     
        enemyHealth.TakeDamage(amount);
    }


    public override void StayCollision(PlayerCollider playerCollider)
    {
        if (canHitPlayer)
        {
            canHitPlayer = false;
            playerCollider.player.ChangeHP(-20);
            timer.StartTimer(() => { canHitPlayer = true; }, 1);
        }
        
    }
    private List<FovCollidable.FovCollider> fovs = new List<FovCollidable.FovCollider> ();

    
    public override void EnterCollision(FovCollidable.FovCollider fovElement)
    {
        spriteRenderer.enabled = true;
        fovs.Add(fovElement);
    }

    public override void ExitCollision(FovCollidable.FovCollider fovElement)
    {
        fovs.Remove(fovElement);
        if(fovs.Count == 0 ) {
            spriteRenderer.enabled = false;
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
}
