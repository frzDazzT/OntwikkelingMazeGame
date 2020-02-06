using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawning : MonoBehaviour
{
    public List<GameObject> keys = new List<GameObject>();
    public List<GameObject> keySpawningPositions = new List<GameObject>();
    private void Start()
    {
        for (int i = 0; i < keys.Count; i++)
        {
            int index = Random.Range(0, keySpawningPositions.Count);
            Instantiate(keys[i], keySpawningPositions[index].transform.position, keys[i].transform.rotation);
        }
    }
}
