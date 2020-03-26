using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawning : MonoBehaviour
{
    public List<GameObject> keys = new List<GameObject>();
    public List<GameObject> keySpawningPositions = new List<GameObject>();
    [HideInInspector]
    public GameObject key;
    private void Start()
    {
        SpawnKey();
    }

    public void SpawnKey()
    {
        if(key != null)
        {
            Destroy(key);
        }

        for (int i = 0; i < keys.Count; i++)
        {
            int index = Random.Range(0, keySpawningPositions.Count);
            key = Instantiate(keys[i], keySpawningPositions[index].transform.position, keys[i].transform.rotation);
            key.SetActive(true);
        }
    }

}
