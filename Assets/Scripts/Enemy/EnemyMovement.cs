using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    private Func<Vector2> target;
    private bool noticedPlayer;
    
    private void Update()
    {
        if (target != null)
        {
            if (GetAudioEvent() == EnemySound.EnemyEvent.idle)
            {
                SetAudioEvent(EnemySound.EnemyEvent.noticedPlayer);
            }
            float travel = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target(), travel);
        }
    }

    public void setTarget(Func<Vector2> target)
    {
        this.target = target;
    }

    private void SetAudioEvent(EnemySound.EnemyEvent enemyEvent)
    {
        if (gameObject.GetComponent<EnemyAudioHandler>() != null) 
        {
            gameObject.GetComponent<EnemyAudioHandler>().SetMode(enemyEvent);
        }
    }

    private EnemySound.EnemyEvent GetAudioEvent()
    {
        if (gameObject.GetComponent<EnemyAudioHandler>() != null)
        {
            return gameObject.GetComponent<EnemyAudioHandler>().GetMode();
        }
        return EnemySound.EnemyEvent.none;
    }
}
