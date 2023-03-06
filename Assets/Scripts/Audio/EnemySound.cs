using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static BatonAudio;
using static DoorAudio;
using static EnemySound;

public class EnemySound : Audio
{
    public AudioClip death;
    public List<AudioClip> idleSounds;
    public AudioClip attack;
    public AudioClip[] usedIdleSounds;
    public EnemyEvent enemyStatus;
    public int enemyID;
    public AudioSource noticeSoundSource;
    public bool hasBeenSeen;

    public enum EnemyEvent
    {
        idle,
        notice,
        attack,
        death
    }


    private void Awake()
    {
        hasBeenSeen = false;
        usedIdleSounds = new AudioClip[3];
        enemyStatus = EnemyEvent.idle;
        enemyID = 2;
        EnemyAudioHandler eah = GameObject.Find("EnemyAudioHandler").GetComponent<EnemyAudioHandler>();
        idleSounds = eah.idleSounds2;
        /*switch (enemyID)
            {
                case 1:
                    idleSounds = eah.idleSounds1;
                    noticeSounds = eah.noticeSounds1;
                    attackSounds = eah.attackSounds1;

                    break;
                case 2:
                    idleSounds = eah.idleSounds2;
                    noticeSounds = eah.noticeSounds2;
                    attackSounds = eah.attackSounds2;
                    break;
                case 3:
                    idleSounds = eah.idleSounds3;
                    noticeSounds = eah.noticeSounds3;
                    attackSounds = eah.attackSounds3;
                    break;
                case 4:
                    idleSounds = eah.idleSounds4;
                    noticeSounds = eah.noticeSounds4;
                    attackSounds = eah.attackSounds4;
                    break;
            }*/
            
    }

    private void Update()
    {
        switch (enemyStatus)
        {
            case EnemyEvent.idle:
                if (!source.isPlaying)
                {
                    source.volume = 0.855f;
                    PlayAudio(EnemyEvent.idle);
                }
                break;
            case EnemyEvent.notice:
                noticeSoundSource.Play();
                break;
        }
        
    }

    public void PlayAudio(EnemyEvent enemyEvent)
    {
        switch (enemyEvent)
        {
            case EnemyEvent.idle:
                IdleSound();
                break;
            case EnemyEvent.notice:
                if (!hasBeenSeen)
                {
                    source.clip = attack;
                    source.Play();
                }
                break;
            case EnemyEvent.attack:
                source.clip = attack;
                source.Play();
                break;
            case EnemyEvent.death:
                PlayAudio(death);
                break;
            default: break;
        }
    }

    public void IdleSound()
    {
        //AudioClip clip = GetUniqueRandomSound(idleSounds, usedIdleSounds);
        var clip = idleSounds[Random.Range(0, idleSounds.Count - 1)];
        if (clip != null)
        {
            source.clip = clip;
            source.Play();
            AddToUsedSounds(usedIdleSounds, clip);
        }
        else
        {
            Debug.Log("clip name is null");
        }
    }

    /*public void NoticeSound()
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
    }*/

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
