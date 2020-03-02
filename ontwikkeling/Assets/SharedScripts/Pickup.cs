using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameObject player;
    public GameObject manager;
    public bool level1Key, level2Key, level3Key;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Key>())
        {
            if (collision.gameObject.GetComponent<Key>().fakeKey)
            {
               // Debug.Log("time taken off");
                collision.gameObject.SetActive(false);
            }
            else
            {
                //Debug.Log("key added");   

                manager.GetComponent<ObjectiveManager>().CompletedObjective(ObjectiveType.Key);

                if (collision.gameObject.CompareTag("KeyLevel1"))
                {
                    level1Key = true;
                }
                if (collision.gameObject.CompareTag("KeyLevel2"))
                {
                    level2Key = true;
                }
                if (collision.gameObject.CompareTag("KeyLevel3"))
                {
                    level3Key = true;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }
}
