using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicSystem : StaticInstance<MusicSystem>
{
    [SerializeField] private List<AudioClip> musicClips;
    
    void Start()
    {
        AudioSystem.Instance.onMusicClipEnded.AddListener(PlayRandomMusic);
        PlayRandomMusic();
    }

    void PlayRandomMusic()
    {
        if (musicClips is { Count: > 0 })
        {
            int randomIndex = Random.Range(0, musicClips.Count);
            AudioSystem.Instance.PlayMusic(musicClips[randomIndex]);
        }
        else
        {
            Debug.LogWarning("No music clips available in the list.");
        }
    }
}