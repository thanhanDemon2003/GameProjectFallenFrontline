using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] Slider musicSlider;


    void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }

    }
    public void SetMusicVolume()
    {
        AudioListener.volume = musicSlider.value;
        Save();
    }
    
    private void Load()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume",musicSlider.value);
    }
}
