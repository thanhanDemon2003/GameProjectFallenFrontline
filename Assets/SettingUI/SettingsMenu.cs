using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions; // mang do phan giai

    private void Start()
    {
        resolutions = Screen.resolutions;

        // danh sach do phan giai
        resolutionDropdown.ClearOptions();
        foreach (Resolution res in resolutions)
        {
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(res.width + " x " + res.height));
        }

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);

        fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);

        LoadAndApplySettings();
    }

    private void LoadAndApplySettings()
    {
        int selectedResolutionIndex = PlayerPrefs.GetInt("SelectedResolutionIndex", FindResolutionIndex(1920, 1080));
        bool fullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;

        resolutionDropdown.value = selectedResolutionIndex;
        fullscreenToggle.isOn = fullscreen;

        ApplySettings(selectedResolutionIndex, fullscreen);
    }

    private int FindResolutionIndex(int width, int height)
    {
        for (int i = 0; i < resolutions.Length; i++)
        {
            Resolution res = resolutions[i];
            if (res.width == width && res.height == height)
            {
                return i;
            }
        }
        return 0;
    }

    private void OnResolutionChanged(int resolutionIndex)
    {
        bool fullscreen = fullscreenToggle.isOn;
        ApplySettings(resolutionIndex, fullscreen);
    }

    private void OnFullscreenChanged(bool fullscreen)
    {
        int resolutionIndex = resolutionDropdown.value;
        ApplySettings(resolutionIndex, fullscreen);
    }

    private void ApplySettings(int resolutionIndex, bool fullscreen)
    {
        Resolution selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullscreen);

        PlayerPrefs.SetInt("SelectedResolutionIndex", resolutionIndex);
        PlayerPrefs.SetInt("Fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }
}
