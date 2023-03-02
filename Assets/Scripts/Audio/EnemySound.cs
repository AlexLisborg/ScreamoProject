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
    public List<AudioClip> idleSounds;
    public List<AudioClip> noticeSounds;
    public List<AudioClip> attackSounds;
    private Dictionary<EnemyEvent, List<AudioClip>> usedSounds;
    private Dictionary<EnemyEvent, List<AudioClip>> sounds;

    private void Start()
    {
        usedSounds = new Dictionary<EnemyEvent, List<AudioClip>> 
        { 
            { EnemyEvent.idle, new List<AudioClip>() }, 
            { EnemyEvent.attack, new List<AudioClip>() }, 
            { EnemyEvent.noticedPlayer, new List<AudioClip>() } 
        };

        sounds = new Dictionary<EnemyEvent, List<AudioClip>> 
        { 
            { EnemyEvent.idle, idleSounds }, 
            { EnemyEvent.attack, noticeSounds }, 
            { EnemyEvent.noticedPlayer, attackSounds } };
    }

    public enum EnemyEvent
    {
        idle,
        noticedPlayer,
        movingTowardPlayer,
        attack,
        death,
        none
    }

    public void SetAudio(EnemyEvent enemyEvent)
    {
        AudioClip clip = GetUniqueRandomSound(sounds[enemyEvent], usedSounds[enemyEvent]);
        if (clip != null)
        {
            Debug.Log("Set audio clip to: " + clip.name);
            source.clip = clip;
            AddToUsedSounds(enemyEvent, clip);
        }
    }

    private void AddToUsedSounds(EnemyEvent enemyEvent, AudioClip sound)
    {
        List<AudioClip> usedClips = usedSounds[enemyEvent];
        if(usedClips.Count() == 3)
        {
            Debug.Log("Used clips size = " + usedSounds[enemyEvent].Count());
            usedSounds[enemyEvent] = new List<AudioClip> { sound, usedClips[0], usedClips[1] };
        }
        else
        {
            // Debug.Log("Used sound size before add = " + usedSounds[enemyEvent].Count());
            usedClips.Add(sound);
            
            usedSounds[enemyEvent] = usedClips;
            // Debug.Log("Used sound size = " + usedSounds[enemyEvent].Count());
        }
    }

    public float GetClipLength()
    {
        return source.clip.length;
    }

    public void PlayClip()
    {
        source.Play();
    }

    public bool IsAudioPlaying()
    {
        return source.isPlaying;
    }
}
