using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
