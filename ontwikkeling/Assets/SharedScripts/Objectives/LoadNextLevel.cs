using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    public float detectionRange;
    public GameObject manager;
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
                }
                else
                {
                    //display action text "Find the key first, then you can leave"
                    Debug.Log("find key");
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
