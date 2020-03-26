using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    GameObject player;
    GameObject start;
    public GameObject keySpawningObj;
    public GameObject settingsCanvas;
    public GameObject pauseCanvas;

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
                keySpawningObj.GetComponent<KeySpawning>().SpawnKey();           
                //level 1 key to false
                if(SceneManager.GetActiveScene().name == "Level1")
                {
                    player.GetComponent<Pickup>().SetKeyBoolTo(1, false);
                }
                //level 2 key to false
                if (SceneManager.GetActiveScene().name == "level 2")
                {
                    player.GetComponent<Pickup>().SetKeyBoolTo(2, false);
                }
                //level 3 key to false
                if (SceneManager.GetActiveScene().name == "Level3Scene")
                {
                    player.GetComponent<Pickup>().SetKeyBoolTo(3, false);
                }
                player.GetComponent<Player>().UnPause();
                break;
            case 2:
                //restart timer and go back to main menu
                player.GetComponent<Timer>().ResetTimer();
                //level 1 key to false
                if (SceneManager.GetActiveScene().name == "Level1")
                {
                    player.GetComponent<Pickup>().SetKeyBoolTo(1, false);
                }
                //level 2 key to false
                if (SceneManager.GetActiveScene().name == "level 2")
                {
                    player.GetComponent<Pickup>().SetKeyBoolTo(2, false);
                }
                //level 3 key to false
                if (SceneManager.GetActiveScene().name == "Level3Scene")
                {
                    player.GetComponent<Pickup>().SetKeyBoolTo(3, false);
                }
                SceneManager.LoadScene(0);
                break;
        }


    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        start = GameObject.FindGameObjectWithTag("Start");
    }
}
