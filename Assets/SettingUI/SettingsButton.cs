using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    private AudioSource[] allAudioSources;

    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
    }

    public void OnSettingsButtonClicked()
    {
        // tam dung am thanh trong gamw
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.Pause();
        }
    }

    public void ResumeAudioSources()
    {
        // tiep tuc am thanh trong game
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }
    }
}
