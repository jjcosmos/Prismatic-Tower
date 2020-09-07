using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearScreenListener : CustomListener
{
    [SerializeField] AudioSource aSource;
    [SerializeField] AudioClip clip;
    public override void Notify()
    {
        base.Notify();
        PersistantCanvas.staticCanvas.RemoveBossText();
        aSource?.PlayOneShot(clip);
        SingletonMusicPlayer.StaticMusicPlayer.SwapTrack(EMusicState.None, false, false);
    }
}
