using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum AudioType { Music, SFX, Voice}
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
    public void PlaySound(int number, AudioSource source, bool loop, AudioType type, float maxDistance)
    {
        source.loop = loop;
        source.clip = SFX[number];
        source.spatialBlend = 1f;
        source.maxDistance = maxDistance;
        if(type == AudioType.SFX)
        source.volume = SFXVolume.value * MasterVolume.value;
        else if (type == AudioType.Voice)
        source.volume = VoiceVolume.value * MasterVolume.value;
        else if (type == AudioType.Music)
        source.volume = MusicVolume.value * MasterVolume.value;
        source.Play();
    }
    
}
