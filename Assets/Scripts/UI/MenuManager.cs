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

    [SerializeField] public List<GameObject> musicMenu;

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
        musicMenu[0].SetActive(true);
        musicMenu[1].SetActive(true);
        musicMenu[2].SetActive(true);
        musicMenu[3].SetActive(true);
        musicMenu[4].SetActive(true);
        musicMenu[5].SetActive(true);
        musicMenu[6].SetActive(true);
        musicMenu[7].SetActive(true);
        musicMenu[8].SetActive(true);
        musicMenu[9].SetActive(true);
        musicMenu[10].SetActive(true);
        musicMenu[11].SetActive(true);
        musicMenu[12].SetActive(true);
        musicMenu[13].SetActive(true);
        musicMenu[14].SetActive(true);
        musicMenu[15].SetActive(true);
        musicMenu[16].SetActive(true);
        musicMenu[17].SetActive(true);
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
        musicMenu[0].SetActive(false);
        musicMenu[1].SetActive(false);
        musicMenu[2].SetActive(false);
        musicMenu[3].SetActive(false);
        musicMenu[4].SetActive(false);
        musicMenu[5].SetActive(false);
        musicMenu[6].SetActive(false);
        musicMenu[7].SetActive(false);
        musicMenu[8].SetActive(false);
        musicMenu[9].SetActive(false);
        musicMenu[10].SetActive(false);
        musicMenu[11].SetActive(false);
        musicMenu[12].SetActive(false);
        musicMenu[13].SetActive(false);
        musicMenu[14].SetActive(false);
        musicMenu[15].SetActive(false);
        musicMenu[16].SetActive(false);
        musicMenu[17].SetActive(false);
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
