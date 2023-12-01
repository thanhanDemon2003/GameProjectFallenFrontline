using FPS.Player;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused = false;
    private AudioSource[] allAudioSources;
    public GameObject GameObject;
    private PlayerController scriptInstance;

    void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        scriptInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        scriptInstance.canControl = true;
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
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        scriptInstance.canControl = false;
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
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        scriptInstance.canControl = true;
    }
}
