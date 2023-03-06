using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooAudio : Audio
{
    public AudioClip movement;
    public AudioClip heartbeat;

    public void GooMovementAudio()
    {
        PlayAudio(movement);
    }
}
