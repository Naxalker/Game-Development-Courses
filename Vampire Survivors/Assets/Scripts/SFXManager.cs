using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    [SerializeField] AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }

    public void PlaySFX(int sfxToPlay)
    {
        soundEffects[sfxToPlay].Stop();
        soundEffects[sfxToPlay].Play();
    }

    public void PlaySFXPitched(int sfxToPlay)
    {
        soundEffects[sfxToPlay].pitch = Random.Range(.8f, 1.2f);
        PlaySFX(sfxToPlay);
    }
}
