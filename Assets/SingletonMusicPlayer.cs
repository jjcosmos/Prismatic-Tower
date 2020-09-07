using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMusicPlayer : MonoBehaviour
{
    public static SingletonMusicPlayer StaticMusicPlayer;
    public EMusicState currentTrack;
    public float fadeOutSpeed = 1;
    public float fadeInSpeed = 1;
    public AudioClip ambientTrack;
    public AudioClip bossTrack;
    public AudioClip menuTrack;
    private Coroutine TrackSwapCoroutine;
    private AudioSource myAudiosource;
    private float maxVolume;
    private void Awake()
    {
        if(StaticMusicPlayer == null)
        {
            StaticMusicPlayer = this;
            DontDestroyOnLoad(this.gameObject);
            myAudiosource = GetComponent<AudioSource>();
            maxVolume = myAudiosource.volume;
            currentTrack = EMusicState.Menu;
            AssignClip();
            if (myAudiosource.clip != null) { myAudiosource.Play(); }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void SwapTrack(EMusicState track, bool fadeIn, bool startImmediate)
    {
        if (TrackSwapCoroutine != null)
        {
            StopCoroutine(TrackSwapCoroutine);
        }
        TrackSwapCoroutine = StartCoroutine(SwapCoroutine(track, fadeIn, startImmediate));
    }

    private IEnumerator SwapCoroutine(EMusicState track, bool fadeIn, bool startImmediate)
    {
        if (startImmediate) { myAudiosource.volume = 0; }
        while(myAudiosource.volume > 0)
        {
            myAudiosource.volume -= Time.deltaTime * fadeOutSpeed;
            yield return null;
        }

        currentTrack = track;
        AssignClip();
        if (myAudiosource.clip != null) { myAudiosource.Play(); }

        if (fadeIn) 
        { 
            while(myAudiosource.volume < maxVolume)
            {
                myAudiosource.volume += Time.deltaTime * fadeInSpeed;
                yield return null;
            }
        }
        else
        {
            myAudiosource.volume = maxVolume;
        }

    }

    private void AssignClip()
    {
        if (currentTrack == EMusicState.None)
            myAudiosource.clip = null;
        else if(currentTrack == EMusicState.Ambient)
            myAudiosource.clip = ambientTrack;
        else if (currentTrack == EMusicState.Boss)
            myAudiosource.clip = bossTrack;
        else if (currentTrack == EMusicState.Menu)
            myAudiosource.clip = menuTrack;
    }
}



public enum EMusicState { None, Ambient, Boss, Menu};