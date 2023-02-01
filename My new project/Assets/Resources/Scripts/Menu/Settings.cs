using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Dropdown _qualityDropdown;

    private Resolution[] resolutions;
    private readonly string _fullscreenPref = "FullscreenPreference";
    private readonly string _resolution = "ResolutionPreference";
    private readonly string _qualityPref = "QualitySettingPreference";

    private void Start()
    {
        _resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt(_qualityPref, _qualityDropdown.value);
        PlayerPrefs.SetInt(_resolution, _resolutionDropdown.value);
        PlayerPrefs.SetInt(_fullscreenPref, System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey(_qualityPref))
        {
            _qualityDropdown.value = PlayerPrefs.GetInt(_qualityPref);
        }
        else
        {
            _qualityDropdown.value = 3;
        }
        if (PlayerPrefs.HasKey(_resolution))
        {
            _resolutionDropdown.value = PlayerPrefs.GetInt(_resolution);
        }
        else
        {
            _resolutionDropdown.value = currentResolutionIndex;
        }
        if (PlayerPrefs.HasKey(_fullscreenPref))
        {
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt(_fullscreenPref));
        }
        else
        {
            Screen.fullScreen = true;
        }
    }
}
