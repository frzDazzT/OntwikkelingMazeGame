using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    GameObject player;
    GameObject start;
    
    public void PauseButtons(int index)
    {
        switch (index)
        {
            case 0:
                player.GetComponent<Player>().UnPause();
                break;
            case 1:
                player.transform.position = start.transform.position;
                //reset all objectives and reset key boolean
                GetComponent<DialogManager>().isDialogOpen = false;
                GetComponent<DialogManager>().dialogCanvas.SetActive(false);
                GetComponent<ObjectiveManager>().ResetObjectives();
                player.GetComponent<Player>().UnPause();
                //resart timer
                break;
            case 2:
                //button settings
                break;
            case 3:
                Application.Quit();
                break;
        }


    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        start = GameObject.FindGameObjectWithTag("Start");
    }
}
