using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Animator settingsAnimator;
    public Animator mainAnimator;
    public GameObject settingsCanvas;
    public GameObject MainCanvas;

    public void ExitFromSettingstoMain()
    {
        settingsAnimator.SetBool("Exit", true);
        StartCoroutine("SwitchCanvasFromSettingsToMain");
    }

    public void ExitFromMainToSettings()
    {
        mainAnimator.SetBool("Exit", true);
        StartCoroutine("SwitchCanvasFromSettingsToSettings");
    }

    public IEnumerator SwitchCanvasFromSettingsToMain()
    {
        yield return new WaitForSeconds(0.6f);
        settingsCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }

    public IEnumerator SwitchCanvasFromSettingsToSettings()
    {
        yield return new WaitForSeconds(0.6f);
        settingsCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }
}
