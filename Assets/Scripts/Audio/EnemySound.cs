using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static DoorAudio;

public class EnemySound : Audio
{
    public AudioClip death;
    public AudioClip[] idleSounds;
    public AudioClip[] noticeSounds;
    public AudioClip[] attackSounds;
    public AudioClip[] usedIdleSounds = new AudioClip[3];
    public AudioClip[] usedNoticeSounds = new AudioClip[3];
    public AudioClip[] usedAttackSounds = new AudioClip[3];

    public enum EnemyEvent
    {
        idle,
        notice,
        attack,
        death
    }

    public void PlayAudio(EnemyEvent enemyEvent)
    {
        switch (enemyEvent)
        {
            case EnemyEvent.idle:
                IdleSound();
                break;
            case EnemyEvent.notice:
                NoticeSound();
                break;
            case EnemyEvent.attack:
                RandomAttackSound();
                break;
            case EnemyEvent.death:
                PlayAudio(death);
                break;
            default: break;
        }
    }

    public void IdleSound()
    {
        AudioClip clip = GetUniqueRandomSound(idleSounds, usedIdleSounds);
        if (clip != null)
        {
            source.clip = clip;
            source.Play();
            AddToUsedSounds(usedIdleSounds, clip);
        }
    }

    public void NoticeSound()
    {
        AudioClip clip = GetUniqueRandomSound(noticeSounds, usedNoticeSounds);
        if (clip != null)
        {
            source.clip = clip;
            source.Play();
            AddToUsedSounds(usedNoticeSounds, clip);
        }
    }

    public void RandomAttackSound()
    {
        AudioClip clip = GetUniqueRandomSound(attackSounds, usedAttackSounds);
        if(clip != null)
        {
            source.clip = clip;
            source.Play();
            AddToUsedSounds(usedAttackSounds, clip);
        }
    }

    private void AddToUsedSounds(AudioClip[] usedSounds, AudioClip sound)
    {
        if (usedSounds[1] != null)
        {
            usedSounds[2] = usedSounds[1];
        }
        if (usedSounds[0] != null)
        {
            usedSounds[1] = usedSounds[0];
        }
        usedSounds[0] = sound;
    }
}
