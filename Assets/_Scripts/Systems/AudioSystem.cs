using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

/// <summary>
/// Insanely basic audio system which supports 3D sound.
/// Ensure you change the 'Sounds' audio source to use 3D spatial blend if you intend to use 3D sounds.
/// </summary>
public class AudioSystem : StaticInstance<AudioSystem>
{ 
    public UnityEvent onMusicClipEnded;
    
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundsSource;

    private Coroutine _waitForMusicEndRoutine;

    public void PlayMusic(AudioClip clip) {
        _musicSource.clip = clip;
        _musicSource.Play();

        _waitForMusicEndRoutine = StartCoroutine(WaitForMusicToEnd());
    }

    public void PlaySound(AudioClip clip, Vector3 pos, float vol = 1) {
        _soundsSource.transform.position = pos;
        PlaySound(clip, vol);
    }

    public void PlaySound(AudioClip clip, float vol = 1) {
        _soundsSource.PlayOneShot(clip, vol);
    }

    IEnumerator WaitForMusicToEnd()
    {
        yield return new WaitUntil(() => _musicSource.time >= _musicSource.clip.length);
        onMusicClipEnded.Invoke();
    }


    protected override void OnApplicationQuit()
    {
        StopCoroutine(_waitForMusicEndRoutine);
        base.OnApplicationQuit();
    }
}