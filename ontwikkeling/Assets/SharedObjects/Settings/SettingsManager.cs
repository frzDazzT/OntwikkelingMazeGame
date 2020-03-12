using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer mainAudio;
    public Dropdown resolutionDropDown;

    Resolution[] resolutions;
    
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> resOptions = new List<string>();

        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resOptions.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resolutionDropDown.AddOptions(resOptions);

        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }
    public void SetResolution(int resIndex)
    {
        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        mainAudio.SetFloat("MainVolume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    
    public void SetFullScreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }
}
