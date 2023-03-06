using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemySound;

public class BatonAudio : Audio
{
    public AudioClip swing;
    public List<AudioClip> hit;
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
                ChangeVolumeTo(40);
                PlayAudio(swapTo);
                break;
            case BatonEvent.swing:
                ChangeVolumeTo(100);
                PlayAudio(swing);
                break;
            case BatonEvent.hit:
                PlayRandomAudio(hit);
                break;
            default: break;
        }
    }
}
