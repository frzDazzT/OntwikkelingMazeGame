using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private void Awake()
    {
        var timer = GetComponent<Timer>();
        if (timer.CheckIfHighscore())
        {
            timer.SetCurrentToHighscore();
        }
    }
}
