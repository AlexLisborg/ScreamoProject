using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySound;

public class BatonAudio : Audio
{
    public GameObject player;
    public AudioClip swing;
    public AudioClip hit;
    public AudioClip swapTo;

    public enum BatonEvent
    {
        swapTo,
        swing,
        hit
    }

    public void PlayAudio(BatonEvent batonEvent)
    {
        switch (batonEvent)
        {
            case BatonEvent.swapTo:
                PlayAudioFromSource(swapTo, player);
                break;
            case BatonEvent.swing:
                PlayAudioFromSource(swing, player);
                break;
            case BatonEvent.hit:
                PlayAudioFromSource(hit, player);
                break;
            default: break;
        }
    }
}
