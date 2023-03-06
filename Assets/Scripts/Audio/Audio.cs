using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Audio : MonoBehaviour
{
    public AudioSource source;

    protected void PlayAudio(AudioClip audioClip)
    {
        Debug.Log("Checking if audio clip is null");
        if (audioClip != null)
        {
            Debug.Log("Change source to:");
            Debug.Log(source.clip.name);
            source.clip = audioClip;
            source.Play();
        }
        else
        {
            Debug.Log("Audio clip is null");
        }
    }

    protected void PlayRandomAudio(List<AudioClip> audioClips)
    {
        var i = Random.Range(0, audioClips.Count - 1);
        Debug.Log("RANDOM SOUND"); 
        Debug.Log(i);
        if (audioClips[i] != null)
        {
            source.clip = audioClips[i];
            source.Play();
        }
        else
        {
            Debug.Log("Audio clip is null");
        }
    }

    protected void StopAudio()
    {
        source.Stop();
        Debug.Log("Audio stopped");
    }

    public void ChangeVolumeTo(int v)
    {
        source.volume = v;
    }

    protected IEnumerator FadeVolume()
    {
        float currentTime = 0;
        float start = source.volume;
        while (currentTime < 10)
        {
            currentTime += Time.deltaTime;
            source.volume = Mathf.Lerp(start, 0, currentTime / 10);
            yield return null;
        }
        yield break;
    }

    protected AudioClip GetUniqueRandomSound(AudioClip[] sounds, AudioClip[] usedSounds)
    {
        if (sounds != null)
        {
            List<AudioClip> availableSounds = new();
            if (usedSounds != null)
            {
                foreach (AudioClip usedSound in usedSounds)
                {
                    if (!sounds.Contains(usedSound))
                    {
                        availableSounds.Add(usedSound);
                    }
                }
            } else
            {
                availableSounds.AddRange(sounds);
            }
            var randInd = Random.Range(0, availableSounds.Count);
            var sound = availableSounds[randInd];
            return sound;
        }
        return null;
    }
}
