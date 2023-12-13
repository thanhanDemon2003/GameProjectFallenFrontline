using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class IntroScripts : MonoBehaviour
{
    public VideoPlayer video;
    void Awake()
    {
        video.loopPointReached += LoadNextScene;
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
