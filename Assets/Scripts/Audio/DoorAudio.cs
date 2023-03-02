using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorAudio : Audio
{
    public AudioClip openDoor;
    public AudioClip tryUnlockDoor;
    public AudioClip unlockDoor;

    public enum DoorEvent
    {
        open,
        unlock,
        tryOpen
    }

    public void PlayAudio(DoorEvent doorEvent)
    {
        switch (doorEvent)
        {
            case DoorEvent.open:
                PlayAudio(openDoor);
                break;
            case DoorEvent.unlock:
                PlayAudio(unlockDoor);
                break;
            case DoorEvent.tryOpen:
                PlayAudio(tryUnlockDoor);
                break;
            default: break;
        }
    }
}
