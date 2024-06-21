using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //AudioSource
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    //AudioClip
    public AudioClip bgMusic;
    public AudioClip coinCollect;
    public AudioClip explosion;
    public AudioClip death;
    public AudioClip staminaReplenish;
    public AudioClip drownSound;
    public AudioClip covenDrownSound;
    public AudioClip clownDrownSound;
    public AudioClip freminetDrownSound;
    public AudioClip fireflyDrownSound;
    public AudioClip powerUp;

    private void Start(){
        musicSource.clip = bgMusic;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void PlaySFX(AudioClip clip){
        sfxSource.PlayOneShot(clip);
    }
}
