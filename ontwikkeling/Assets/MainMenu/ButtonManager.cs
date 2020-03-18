using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public Animator settingsAnimator;
    public Animator mainAnimator;
    public GameObject settingsCanvas;
    public GameObject MainCanvas;

    public void StartAndQuitButton(int index)
    {
        switch (index)
        {
            case 0:
                //start overworld level
                SceneManager.LoadScene(1);
                break;
            case 1:
                //quit game
                Application.Quit();
                break;
        }
    }


    /*<summary>
     Stuff below is so that the fade in and out animations get called and work smoothly       
    */
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
        yield return new WaitForSeconds(0.4f);
        settingsCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }

    public IEnumerator SwitchCanvasFromSettingsToSettings()
    {
        yield return new WaitForSeconds(0.4f);
        settingsCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }
}
