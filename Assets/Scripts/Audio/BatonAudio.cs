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
                PlayAudio(swapTo);
                break;
            case BatonEvent.swing:
                PlayAudio(swing);
                break;
            case BatonEvent.hit:
                PlayAudio(hit);
                break;
            default: break;
        }
    }
}
