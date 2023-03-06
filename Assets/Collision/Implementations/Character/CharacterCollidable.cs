using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollidable : Colidable
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private Timer timer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new CharacterColider(go, enemyHealth, rb, enemyMovement, timer, spriteRenderer);
    }
}
