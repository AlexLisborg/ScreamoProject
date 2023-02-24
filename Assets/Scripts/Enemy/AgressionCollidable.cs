using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressionCollidable : Colidable
{
    [SerializeField] private EnemyMovement enemyMovement;
    public override AbsColider GetColiderInstance(GameObject go)
    {
        return new AgressionCollider(go, enemyMovement);
    }

    public class AgressionCollider : AbsColider
    {
        private EnemyMovement enemyMovement;
        public AgressionCollider(GameObject parent, EnemyMovement enemyMovement) : base(parent)
        {
            this.enemyMovement = enemyMovement;
        }

        public override void AcceptEnter(AbsColider other) { }

        public override void AcceptExit(AbsColider other) {}

        public override void AcceptStay(AbsColider other) { }

        public override void EnterCollision(PlayerCollider playerCollider)
        {
            enemyMovement.setTarget(playerCollider.player.getPos);
        }
    }
}
