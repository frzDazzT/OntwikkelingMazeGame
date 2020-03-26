using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldTeleports : MonoBehaviour
{
    public bool level1, level2, level3;

    private void OnTriggerEnter(Collider other)
    {
        if (level1)
        {
            //load level 1
            SceneManager.LoadScene(2);
        }

        if (level2)
        {
            if (other.GetComponent<Pickup>().ReturnIfKeyGotten(1))
            {
                //load level 2
                SceneManager.LoadScene(3);
            }
        }

        if (level3)
        {
            if (other.GetComponent<Pickup>().ReturnIfKeyGotten(2))
            {
                //load level 3
                SceneManager.LoadScene(4);
            }
        }
    }
}
