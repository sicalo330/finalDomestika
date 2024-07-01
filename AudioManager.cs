using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager obj;
    public AudioClip jump;
    public AudioClip coin;
    public AudioClip hit;
    public AudioClip gui;
    public AudioClip enemyHit;
    public AudioClip win;
    public AudioSource audioSource;
    public AudioSource audioBg;

    private void Awake(){
        obj = this;
        audioSource = gameObject.AddComponent<AudioSource>(); 
    }

    public void playCoin(){playSound(coin);}
    public void playHit(){playSound(hit);}
    public void playEnemyHit(){playSound(enemyHit);}
    public void playWin(){playSound(win);}

    public void playSound(AudioClip clip){
        audioSource.PlayOneShot(clip);
    }

    void playSoundBg(AudioClip clip){
        audioBg.PlayOneShot(clip);
    }

    private void OnDestroy(){
        obj = null;
    }
}
