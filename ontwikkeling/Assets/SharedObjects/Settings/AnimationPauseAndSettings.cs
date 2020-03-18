using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPauseAndSettings : MonoBehaviour
{ 
    public Animator settingsAnimator;
    public Animator pauseAnimator;
    public GameObject settingsCanvas;
    public GameObject pauseMenu;

    public void ExitFromSettingstoPause()
    {
        //trigger to go back
        settingsAnimator.SetTrigger("Exit");
        StartCoroutine("SwitchCanvasFromSettingsToPause");
    }

    public void ExitFromPauseToSettings()
    {
        //trigger to go back
        pauseAnimator.SetTrigger("Exit");
        StartCoroutine("SwitchCanvasFromPauseToSettings");
    }
    public IEnumerator SwitchCanvasFromSettingsToPause()
    {
        yield return new WaitForSeconds(0.3f);
        settingsCanvas.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public IEnumerator SwitchCanvasFromPauseToSettings()
    {
        yield return new WaitForSeconds(0.3f);
        settingsCanvas.SetActive(true);
        pauseMenu.SetActive(false);
    }
}


