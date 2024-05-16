using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

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

    float defaultMaxDistance = 10f;
    AudioType defaultType = AudioType.SFX;

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
        float volume = SetVolumeToType(type);
        source.volume = volume;
        source.Play();
    }
    public void PlaySound(int number, AudioSource source, bool loop)
    {
        source.loop = loop;
        source.clip = SFX[number];
        source.spatialBlend = 1f;
        source.maxDistance = defaultMaxDistance;
        float volume = SetVolumeToType(defaultType);
        source.volume = volume;
        source.Play();
    }
    private float SetVolumeToType(AudioType type)
    {
        float f = 0f;
        if (defaultType == AudioType.SFX)
            f = SFXVolume.value * MasterVolume.value;
        else if (defaultType == AudioType.Voice)
            f = VoiceVolume.value * MasterVolume.value;
        else if (defaultType == AudioType.Music)
            f = MusicVolume.value * MasterVolume.value;
        return f;
    }
}
