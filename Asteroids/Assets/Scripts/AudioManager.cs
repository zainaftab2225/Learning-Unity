using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static AudioSource audioSource;
    static AudioSource bgAudioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source, AudioSource bgsource)
    {
        audioSource = source;
        bgAudioSource = bgsource;
        audioClips.Add(AudioClipName.AsteroidHit, 
            Resources.Load<AudioClip>("hit"));
        audioClips.Add(AudioClipName.PlayerDeath,
            Resources.Load<AudioClip>("die"));
        audioClips.Add(AudioClipName.PlayerShot,
            Resources.Load<AudioClip>("shoot"));
        audioClips.Add(AudioClipName.BackgroundMusic,
            Resources.Load<AudioClip>("mythica"));
        audioClips.Add(AudioClipName.Engine,
            Resources.Load<AudioClip>("engine"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }

    public static void PlayBGMusic(AudioClipName name)
    {
        AudioClip bg_music = audioClips[name];
        bgAudioSource.loop = true;
        bgAudioSource.volume = 0.4f;
        bgAudioSource.clip = bg_music;
        bgAudioSource.Play();
    }
}
