using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
    List<Resolution> resolutions;

    void Start() 
    {
        Resolution[] resolutionsWithRepeats = Screen.resolutions;
        
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        resolutions = new List<Resolution>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutionsWithRepeats.Length; i++)
        {
            string option = resolutionsWithRepeats[i].width + "x" + resolutionsWithRepeats[i].height;

            if (options.LastOrDefault() != option)
            {
                options.Add(option);
                resolutions.Add(resolutionsWithRepeats[i]);

                if (resolutionsWithRepeats[i].width == Screen.currentResolution.width &&
                resolutionsWithRepeats[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = options.Count() - 1;
                }
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }

    public void SetFullscreen(bool isFullscreen) 
    {
        Screen.fullScreen = isFullscreen;
    }
}
