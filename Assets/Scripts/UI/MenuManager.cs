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
    void Awake()
    {
        pause.SetActive(false);
        settings.SetActive(false);
        ControlsMenu.SetActive(false);
        MusicMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!paused)
        {
            //canvas.SetActive(true);
            pause.SetActive(true);
            settings.SetActive(false);
            paused = true;
        }
        else if (paused)
        {
            //canvas.SetActive(false);
            settings.SetActive(false);
            pause.SetActive(false);
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

    public void NewRun()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        settings.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void Back()
    {
        settings.SetActive(false);
        MusicMenu.SetActive(false);
        ControlsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
