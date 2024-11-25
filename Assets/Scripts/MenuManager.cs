using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject settings;
    [SerializeField] private GameObject pause;
    [SerializeField] private bool paused;
    void Awake()
    {
        pause.SetActive(false);
        settings.SetActive(false);
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

    public void Settings()
    {
        settings.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
