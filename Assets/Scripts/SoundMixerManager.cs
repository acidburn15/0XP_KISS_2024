using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundMixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    private void Start()
    {
        SoundParameterSaving.Instance.SetMasterVolume(0.1f);
        SoundParameterSaving.Instance.SetSoundFXVolume(0.1f);
        SoundParameterSaving.Instance.SetMusicVolume(0.01f);
    }

    public void SetMasterVolume(float level)
    {
        //audioMixer.SetFloat("MasterVolume", level);
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(level) * 20f);
        SoundParameterSaving.Instance.SetMasterVolume(level);
    }

    public void SetSoundFXVolume(float level)
    {
        //audioMixer.SetFloat("SoundFXVolume", level);
        audioMixer.SetFloat("SoundFXVolume", Mathf.Log10(level) * 20f);
        SoundParameterSaving.Instance.SetSoundFXVolume(level);
    }
    
    public void SetMusicVolume(float level)
    {
        //audioMixer.SetFloat("MusicVolume", level);
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(level) * 20f);
        SoundParameterSaving.Instance.SetMusicVolume(level);
    }
}
