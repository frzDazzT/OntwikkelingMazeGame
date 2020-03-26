using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public bool pause;
    public bool atMainMenu;
    static float secondsCount;
    static int minuteCount;

    //for main menu highscore
    public static float secondsCountHighScore;
    public static int minuteCountHighScore;
    public static bool hasHighscore;

    // Update is called once per frame
    void Update()
    {
        if (!pause && !atMainMenu)
        {
            secondsCount += Time.deltaTime;
            timerText.text = minuteCount + "m:" + (int)secondsCount + "s";
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }
        }

        if (atMainMenu)
        {
            if(secondsCountHighScore > 0)
            {
                timerText.text = minuteCountHighScore + "m:" + (int)secondsCountHighScore + "s";
            }
            else
            {
                timerText.text = "No score";
            }
        }
    }

    public void ResetTimer()
    {
        minuteCount = 0;
        secondsCount = 0;
    }

    public void SetCurrentToHighscore()
    {
        pause = true;
        minuteCountHighScore = minuteCount;
        secondsCountHighScore = secondsCount;
        hasHighscore = true;
    }

    public bool CheckIfHighscore()
    {
        return hasHighscore;
    }
}
