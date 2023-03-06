using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : Audio
{
    public AudioClip walking;
    public AudioClip running;
    public AudioClip walkingBackwards;
    public AudioClip death;
    public AudioClip hit;

    public enum PlayerEvent
    {
        walking,
        running,
        walkingBackwards,
        death,
        notMoving,
        hit
    }

    public void PlayAudio(PlayerEvent playerEvent)
    {
        switch (playerEvent)
        {
            case PlayerEvent.walking:
                source.loop = true;
                PlayAudio(walking);
                break;
            case PlayerEvent.running:
                source.loop = true;
                PlayAudio(running);
                break;
            case PlayerEvent.walkingBackwards:
                source.loop = true;
                PlayAudio(walkingBackwards);
                break;
            case PlayerEvent.death:
                PlayAudio(death);
                break;
            case PlayerEvent.hit:
                PlayAudio(hit);
                break;
        }
    }
}
