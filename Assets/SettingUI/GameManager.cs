﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused = false;
    private AudioSource[] allAudioSources;
    public GameObject GameObject;

    void Start()
    {

        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        isGamePaused = true;


        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
        GameObject.SetActive(true);


    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
        isGamePaused = false;

        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
        GameObject.SetActive(false);

    }
}
