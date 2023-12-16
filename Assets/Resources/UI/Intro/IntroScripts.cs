using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScripts : MonoBehaviour
{
    public VideoPlayer video;
    public VideoPlayer video2;
    void Awake()
    {
        video.Play();
        video.loopPointReached += CheckVideo1Finished;
        video2.gameObject.SetActive(false);
        
    }

    void CheckVideo1Finished(VideoPlayer vp)
    {
        video.gameObject.SetActive(false);
        video2.gameObject.SetActive(true);
        video2.Play();

        video2.loopPointReached += LoadNextScene;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {   if(video.isPlaying)
            {
                return;
            }
            LoadNextScene(video2);
        }
    }
    void LoadNextScene(VideoPlayer vp)
    {
        SceneManager.LoadSceneAsync(1);
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Intro")
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
