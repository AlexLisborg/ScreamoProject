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

        if (audioClip != null)
        {
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

    protected AudioClip GetUniqueRandomSound(List<AudioClip> sounds, AudioClip[] usedSounds)
    {
        if (sounds != null)
        {
            List<AudioClip> availableSounds = new();
            if (usedSounds != null)
            {
                Debug.Log("Used sounds not null");
                foreach (AudioClip clip in sounds)
                {
                    if (!usedSounds.Contains(clip))
                    {
                        Debug.Log("Added sound to list");
                        availableSounds.Add(clip);
                    }
                }
            } else
            {
                Debug.Log("To ELSE");
                availableSounds.AddRange(sounds);
            }
            var randInd = Random.Range(0, availableSounds.Count-1);
            Debug.Log(sounds.Count + " | " +  randInd);
            var sound = availableSounds[randInd];
            if(sound == null)
            {
                Debug.Log("Sound is null");
            }
            return sound;
        }
        Debug.Log("returned null");
        return null;
    }
}
