using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public bool pause = false;
    static float secondsCount;
    static int minuteCount;

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            secondsCount += Time.deltaTime;
            timerText.text = minuteCount + "m:" + (int)secondsCount + "s";
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }
        }
    }

    public void ResetTimer()
    {
        minuteCount = 0;
        secondsCount = 0;
    }
}
