using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAudio : Audio
{
    public AudioClip shoot;
    public AudioClip outOfAmmo;
    public AudioClip hit;
    public AudioClip reload;
    public AudioClip swapTo;
    public AudioClip bulletFlying;

    public enum PistolEvent
    {
        shoot,
        outOfAmmo,
        hit,
        reload,
        swapTo,
        bulletFlying
    }

    public void PlayAudio(PistolEvent pistolEvent)
    {
        switch (pistolEvent)
        {
            case PistolEvent.shoot:
                PlayAudio(shoot);
                break;
            case PistolEvent.outOfAmmo:
                PlayAudio(outOfAmmo);
                break;
            case PistolEvent.hit:
                PlayAudio(hit);
                break;
            case PistolEvent.reload:
                PlayAudio(reload);
                break;
            case PistolEvent.swapTo:
                PlayAudio(swapTo);
                break;
            case PistolEvent.bulletFlying:
                PlayAudio(bulletFlying);
                break;
            default: break;
        }
    }
}
