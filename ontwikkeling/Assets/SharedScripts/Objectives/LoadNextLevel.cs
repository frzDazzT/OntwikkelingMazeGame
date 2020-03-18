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
    float currentTimer;
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
                    if (playerRef.gameObject.GetComponent<Pickup>().level1Key 
                        && !playerRef.gameObject.GetComponent<Pickup>().level2Key 
                        && !playerRef.gameObject.GetComponent<Pickup>().level3Key)
                    {
                        SceneManager.LoadScene(3);                        
                    }

                    if (playerRef.gameObject.GetComponent<Pickup>().level1Key
                        && playerRef.gameObject.GetComponent<Pickup>().level2Key
                        && !playerRef.gameObject.GetComponent<Pickup>().level3Key)
                    {
                        SceneManager.LoadScene(4);
                    }

                    if (playerRef.gameObject.GetComponent<Pickup>().level1Key
                        && playerRef.gameObject.GetComponent<Pickup>().level2Key
                        && playerRef.gameObject.GetComponent<Pickup>().level3Key)
                    {
                        //load ending screen
                        Debug.Log("load ending screen");
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
        yield return new WaitForSeconds(5f);
        obj.SetActive(false);
    }
}
