using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    //[SerializeField] private GameObject canvas;
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject ControlsMenu;
    [SerializeField] private GameObject MusicMenu;
    [SerializeField] private GameObject pause;
    [SerializeField] private bool paused;

    [SerializeField] private PausedGame pausedGame;

    void Awake()
    {
        pause.SetActive(false);
        settings.SetActive(false);
        ControlsMenu.SetActive(false);
        MusicMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause != null)
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!paused && pause != null)
        {
            //canvas.SetActive(true);
            pause.SetActive(true);
            settings.SetActive(false);
            pausedGame = PausedGame.PAUSED;
            AudioManager.instance.SetGamePausedState(pausedGame);
            Debug.Log(pausedGame);
            paused = true;
        }
        else if (paused && pause != null)
        {
            //canvas.SetActive(false);
            settings.SetActive(false);
            pause.SetActive(false);
            pausedGame = PausedGame.PLAYING;
            AudioManager.instance.SetGamePausedState(pausedGame);
            Debug.Log(pausedGame);
            paused = false;
        }
    }

    public void Resume()
    {
        //canvas.SetActive(false);
        settings.SetActive(false);
        pause.SetActive(false);
        paused = false;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NewRun()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settings.SetActive(true); 
        ControlsMenu.SetActive(false);
        MusicMenu.SetActive(false);
        MainMenu.SetActive(false);
    }

    public void Controls()
    {
        settings.SetActive(false);
        ControlsMenu.SetActive(true);
        MusicMenu.SetActive(false);
        MainMenu.SetActive(false);
    }

    public void Music()
    {
        settings.SetActive(false);
        ControlsMenu.SetActive(false);
        MusicMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void SettingsBack()
    {
        settings.SetActive(false);
        MusicMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void MusicBack()
    {
        settings.SetActive(true);
        MusicMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        MainMenu.SetActive(false);
    }

    public void ControlsBack()
    {
        settings.SetActive(true);
        MusicMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        MainMenu.SetActive(false);
    }

    public void OnMouseHoverButton()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonHover, this.transform.position);
    }

    public void OnMouseUnHoverButton()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonUnHover, this.transform.position);
    }

    public void OnMouseClickButton()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonClick, this.transform.position);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
