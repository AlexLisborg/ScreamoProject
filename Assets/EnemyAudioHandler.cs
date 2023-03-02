using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAudioHandler : MonoBehaviour
{
    private float waitTimeAudio;
    private bool playAudio = true;
    private EnemySound audioScript;
    private EnemySound.EnemyEvent mode;

    private void Start()
    {
        audioScript = gameObject.GetComponent<EnemySound>();
        playAudio = true;
        mode = EnemySound.EnemyEvent.idle;
    }
    void Update()
    {
        if (playAudio)
        {
            audioScript.SetAudio(mode);
            audioScript.source.Play();
            playAudio = false;
            waitTimeAudio = audioScript.GetClipLength() + Random.Range(0.1f, 1.2f); ;


            mode = (mode == EnemySound.EnemyEvent.attack) ? (EnemySound.EnemyEvent.movingTowardPlayer) : mode;
            mode = (mode == EnemySound.EnemyEvent.noticedPlayer) ? (EnemySound.EnemyEvent.movingTowardPlayer) : mode;
        }
        else if (waitTimeAudio > 0)
        {
            waitTimeAudio  -= Time.deltaTime;
        }
        else
        {
            playAudio = true;
        } 
    }

    public void SetMode(EnemySound.EnemyEvent mode)
    {
        this.mode = mode;
        audioScript.source.Stop();
        playAudio = true;
    }

    public EnemySound.EnemyEvent GetMode()
    {
        return mode;
    }
}
