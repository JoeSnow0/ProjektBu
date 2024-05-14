using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] FloatReference MasterVolume; 
    [SerializeField] FloatReference MusicVolume;
    [SerializeField] FloatReference SFXVolume;
    [SerializeField] FloatReference VoiceVolume;

    [SerializeField] AudioClip[] Voices;
    [SerializeField] AudioClip[] Music;
    [SerializeField] AudioClip[] SFX;

    /// <summary>
    /// The Number represents the audio files place in the list of sound effects
    /// </summary>
    /// <param name="number"></param>
    /// <param name="source"></param>
    public void PlaySound(int number, AudioSource source, bool loop)
    {
        source.loop = loop;
        source.clip = SFX[number];
        source.volume = SFXVolume.value * MasterVolume.value;
        source.Play();
    }
    /// <summary>
     /// The Number represents the audio files place in the list of music
     /// </summary>
     /// <param name="number"></param>
     /// <param name="source"></param>
    public void PlayMusic(int number, AudioSource source)
    {
        source.clip = SFX[number];
        source.volume = MusicVolume.value * MasterVolume.value;
        source.Play();
    }
    /// <summary>
    /// The Number represents the audio files place in the list of voices
    /// </summary>
    /// <param name="number"></param>
    /// <param name="source"></param>
    public void PlayVoice(int number, AudioSource source)
    {
        source.clip = SFX[number];
        source.volume = VoiceVolume.value * MasterVolume.value;
        source.Play();
    }
}
