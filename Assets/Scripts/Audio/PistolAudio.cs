using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAudio : Audio
{
    public GameObject player;
    public AudioClip shoot;
    public AudioClip outOfAmmo;
    public AudioClip hit;
    public AudioClip reload;
    public AudioClip swapTo;

    public enum PistolEvent
    {
        shoot,
        outOfAmmo,
        hit,
        reload,
        swapTo
    }

    public void PlayAudio(PistolEvent pistolEvent)
    {
        switch (pistolEvent)
        {
            case PistolEvent.shoot:
                PlayAudioFromSource(shoot, player);
                break;
            case PistolEvent.outOfAmmo:
                PlayAudioFromSource(outOfAmmo, player);
                break;
            case PistolEvent.hit:
                PlayAudioFromSource(hit, player);
                break;
            case PistolEvent.reload:
                PlayAudioFromSource(reload, player);
                break;
            case PistolEvent.swapTo:
                PlayAudioFromSource(swapTo, player);
                break;
            default: break;
        }
    }
}
