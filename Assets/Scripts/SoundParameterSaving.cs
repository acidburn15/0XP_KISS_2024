using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundParameterSaving : MonoBehaviour
{
    public static SoundParameterSaving Instance;

    public static float masterVolume = 1f;
    public static float soundFXVolume = 1f;
    public static float musicVolume = 1f;


    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider soundFXVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    [SerializeField] private SoundMixerManager soundMixerManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        masterVolumeSlider.value = masterVolume;
        soundMixerManager.SetMasterVolume(masterVolume);

        soundFXVolumeSlider.value = soundFXVolume;
        soundMixerManager.SetSoundFXVolume(soundFXVolume);

        musicVolumeSlider.value = musicVolume;
        soundMixerManager.SetMusicVolume(musicVolume);
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
    }

        public void SetSoundFXVolume(float volume)
    {
        soundFXVolume = volume;
    }
    
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
    }
}
