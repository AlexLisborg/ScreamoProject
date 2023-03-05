using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static EnemySound;
using static Unity.VisualScripting.Member;

public class Audio : MonoBehaviour
{
    public AudioSource source;

    protected void PlayAudio(AudioClip audioClip)
    {
        if (source == null)
        {
            Debug.Log("Source is null");
        }
        else if (audioClip == null)
        {
            Debug.Log("Audio clip is null");
        }
        else
        {
            // Debug.Log("Played:" + source.clip.name);
            source.clip = audioClip;
            source.Play();
        }
    }

    protected void PlayAudioFromSource(AudioClip audioClip, string tag)
    {
        if (GameObject.Find(tag).GetComponent<AudioSource>() == null)
        {
            Debug.Log("Source is null");
        }
        else if (audioClip == null)
        {
            Debug.Log("Audio clip is null");
        }
        else
        {
            // Debug.Log("Played:" + source.clip.name);
            GameObject.Find(tag).GetComponent<AudioSource>().clip = audioClip;
            GameObject.Find(tag).GetComponent<AudioSource>().Play();
        }
    }

    protected void StopAudio()
    {
        source.Stop();
        Debug.Log("Audio stopped");
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

    protected AudioClip GetUniqueRandomSound(List<AudioClip> sounds, List<AudioClip> usedSounds)
    {   
        if(sounds.Count > 0)
        {
            List<AudioClip> availableSounds = new();
            foreach (AudioClip usedSound in usedSounds)
            {
                if (!sounds.Contains(usedSound))
                {
                    Debug.Log("Does not contain sound");
                    availableSounds.Add(usedSound);
                }
                else
                {
                    Debug.Log("Contain sound");
                }
            }
            var randInd = Random.Range(1, sounds.Count);
            // Debug.Log("Random index is: " + randInd);
            var sound = sounds[randInd];
            return sound;
        }
        Debug.Log("No sound clips added");
        return null;
    }
}
