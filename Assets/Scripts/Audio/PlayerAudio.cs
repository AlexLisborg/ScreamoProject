using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : Audio
{
    public AudioClip walking;
    public AudioClip death;

    public enum PlayerEvent
    {
        walking,
        death
    }

    public void PlayAudio(PlayerEvent playerEvent)
    {
        switch (playerEvent)
        {
            case PlayerEvent.walking:
                PlayAudio(walking);
                break;
            case PlayerEvent.death:
                PlayAudio(death);
                break;
        }
    }
}
