using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] string sceneName;
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
