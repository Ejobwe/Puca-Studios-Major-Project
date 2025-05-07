using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    public EventInstance music;

    private void Start()
    {
        PLAYBACK_STATE playbackState;
        music.getPlaybackState(out playbackState);

        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            music = RuntimeManager.CreateInstance("event:/Music/Game Music");
            music.start();
        }   
    }
}
