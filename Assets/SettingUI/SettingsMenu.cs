using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        // Tạo danh sách các độ phân giải HD, Full HD và 2K
        List<string> resolutionOptions = new List<string>();
        foreach (Resolution res in resolutions)
        {
            if (IsResolutionHD(res) || IsResolutionFullHD(res) || IsResolution2K(res))
            {
                resolutionOptions.Add(res.width + " x " + res.height);
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);

        resolutionDropdown.onValueChanged.AddListener(OnResolutionChanged);
        fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);

        LoadAndApplySettings();
    }

    private bool IsResolutionHD(Resolution resolution)
    {
        return resolution.width == 1280 && resolution.height == 720;
    }

    private bool IsResolutionFullHD(Resolution resolution)
    {
        return resolution.width == 1920 && resolution.height == 1080;
    }

    private bool IsResolution2K(Resolution resolution)
    {
        return resolution.width == 2560 && resolution.height == 1440;
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
