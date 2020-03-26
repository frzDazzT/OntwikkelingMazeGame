using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public float detectionRange;
    public GameObject manager;
    public Text actionText;
    GameObject playerRef;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        Collider[] coll = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider player in coll)
        {
            if (player.gameObject.CompareTag("Player"))
            {
                //set objective complete for finding the exit
                manager.GetComponent<ObjectiveManager>().CompletedObjective(ObjectiveType.Exit);
                //check if Key has been get
                if (manager.GetComponent<ObjectiveManager>().GetIfObjectiveComplete(ObjectiveType.Key))
                {
                    //then load next level and add time to timer
                    Debug.Log("load next level");
                    if (playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(1)
                        && !playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(2)
                        && !playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(3))
                    {
                        SceneManager.LoadScene(3);                        
                    }

                    if (playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(1)
                        && playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(2)
                        && !playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(3))
                    {
                        SceneManager.LoadScene(4);
                    }

                    if (playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(1)
                        && playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(2)
                        && playerRef.gameObject.GetComponent<Pickup>().ReturnIfKeyGotten(3))
                    {
                        //load ending screen (main menu again) & settting highscore
                        playerRef.GetComponent<Timer>().SetCurrentToHighscore();
                        //level 1 key to false
                        if (SceneManager.GetActiveScene().name == "Level1")
                        {
                            playerRef.GetComponent<Pickup>().SetKeyBoolTo(1, false);
                        }
                        //level 2 key to false
                        if (SceneManager.GetActiveScene().name == "level 2")
                        {
                            playerRef.GetComponent<Pickup>().SetKeyBoolTo(2, false);
                        }
                        //level 3 key to false
                        if (SceneManager.GetActiveScene().name == "Level3Scene")
                        {
                            playerRef.GetComponent<Pickup>().SetKeyBoolTo(3, false);
                        }
                        SceneManager.LoadScene(0);
                    }
                }
                else
                {
                    //display action text "Find the key first, then you can leave"
                    actionText.text = "Find the key first, then you can escape";
                    actionText.gameObject.SetActive(true);
                    StartCoroutine(SetFalse(actionText.gameObject));
                    Debug.Log("display text");
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    IEnumerator SetFalse(GameObject obj)
    {
        yield return new WaitForSeconds(6f);
        obj.SetActive(false);
    }
}
