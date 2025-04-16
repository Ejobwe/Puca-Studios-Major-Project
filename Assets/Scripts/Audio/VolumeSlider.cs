using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private enum VolumeType
    {
        MASTER,
        MUSIC,
        AMBIENCE,
        SFX
    }

    [Header("Type")]
    [SerializeField] private VolumeType volumeType;

    private Slider volumeSlider;

    private void Awake()
    {
        volumeSlider = this.GetComponentInChildren<Slider>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Master") && !PlayerPrefs.HasKey("Music") && !PlayerPrefs.HasKey("Ambience") && !PlayerPrefs.HasKey("SFX"))
        {
            AudioManager.instance.masterVolume = 1f;
            AudioManager.instance.musicVolume = 0.5f;
            AudioManager.instance.ambienceVolume = 0.5f;
            AudioManager.instance.sfxVolume = 0.5f;

            PlayerPrefs.SetFloat("Master", AudioManager.instance.masterVolume);
            PlayerPrefs.SetFloat("Music", AudioManager.instance.musicVolume);
            PlayerPrefs.SetFloat("Ambience", AudioManager.instance.ambienceVolume);
            PlayerPrefs.SetFloat("SFX", AudioManager.instance.sfxVolume);

            switch (volumeType)
            {
                case VolumeType.MASTER:
                    volumeSlider.value = PlayerPrefs.GetFloat("Master");
                    break;
                case VolumeType.MUSIC:
                    volumeSlider.value = PlayerPrefs.GetFloat("Music");
                    break;
                case VolumeType.AMBIENCE:
                    volumeSlider.value = PlayerPrefs.GetFloat("Ambience");
                    break;
                case VolumeType.SFX:
                    volumeSlider.value = PlayerPrefs.GetFloat("SFX");
                    break;
                default:
                    Debug.LogWarning("VolumeType not Supported" + volumeType);
                break;
            }
        }
        else
        {
            switch (volumeType)
            {
                case VolumeType.MASTER:
                    volumeSlider.value = PlayerPrefs.GetFloat("Master");
                    break;
                case VolumeType.MUSIC:
                    volumeSlider.value = PlayerPrefs.GetFloat("Music");
                    break;
                case VolumeType.AMBIENCE:
                    volumeSlider.value = PlayerPrefs.GetFloat("Ambience");
                    break;
                case VolumeType.SFX:
                    volumeSlider.value = PlayerPrefs.GetFloat("SFX");
                    break;
                default:
                    Debug.LogWarning("VolumeType not Supported" + volumeType);
                break;
            }
        }
    }

    private void Update()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                volumeSlider.value = AudioManager.instance.masterVolume;
                break;
            case VolumeType.MUSIC:
                volumeSlider.value = AudioManager.instance.musicVolume;
                break;
            case VolumeType.AMBIENCE:
                volumeSlider.value = AudioManager.instance.ambienceVolume;
                break;
            case VolumeType.SFX:
                volumeSlider.value = AudioManager.instance.sfxVolume;
                break;
            default:
                Debug.LogWarning("VolumeType not Supported" + volumeType);
            break;
        }
    }

    public void OnSliderValueChanged()
    {
        switch (volumeType)
        {
            case VolumeType.MASTER:
                AudioManager.instance.masterVolume = volumeSlider.value;
                PlayerPrefs.SetFloat("Master", AudioManager.instance.masterVolume);
                break;
            case VolumeType.MUSIC:
                AudioManager.instance.musicVolume = volumeSlider.value;
                PlayerPrefs.SetFloat("Music", AudioManager.instance.musicVolume);
                break;
            case VolumeType.AMBIENCE:
                AudioManager.instance.ambienceVolume = volumeSlider.value;
                PlayerPrefs.SetFloat("Ambience", AudioManager.instance.ambienceVolume);
                break;
            case VolumeType.SFX:
                AudioManager.instance.sfxVolume = volumeSlider.value;
                PlayerPrefs.SetFloat("SFX", AudioManager.instance.sfxVolume);
                break;
            default:
                Debug.LogWarning("VolumeType not Supported" + volumeType);
            break;
        }
    }
}
