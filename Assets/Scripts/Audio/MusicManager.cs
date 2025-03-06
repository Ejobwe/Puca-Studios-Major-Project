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
        music = RuntimeManager.CreateInstance("event:/Music/Gameplay Music");
        music.start();
    }
}
