using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Transform key1;
    public Transform key2;
    public Transform key3;

    public Transform key1Spawn0;
    public Transform key1Spawn1;
    public Transform key1Spawn2;
    public Transform key1Spawn3;
    public Transform key2Spawn0;
    public Transform key2Spawn1;
    public Transform key2Spawn2;
    public Transform key2Spawn3;
    public Transform key3Spawn0;
    public Transform key3Spawn1;
    public Transform key3Spawn2;
    public Transform key3Spawn3;

    int randomSpawnpoint1;
    int randomSpawnpoint2;
    int randomSpawnpoint3;

    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawnpoint1 = Random.Range(0, 4);
        randomSpawnpoint2 = Random.Range(0, 4);
        randomSpawnpoint3 = Random.Range(0, 4);

        print(randomSpawnpoint1);
        print(randomSpawnpoint2);
        print(randomSpawnpoint3);
    }

    // Update is called once per frame
    void Update()
    {
        // Controls Key 1 spawn
        if (randomSpawnpoint1 == 0)
        {
            key1.position = key1Spawn0.position;
        }
        else if (randomSpawnpoint1 == 1)
        {
            key1.position = key1Spawn1.position;
        }
        else if (randomSpawnpoint1 == 2)
        {
            key1.position = key1Spawn2.position;
        }
        else if (randomSpawnpoint1 == 3)
        {
            key1.position = key1Spawn3.position;
        }

        // Controls Key 2 spawn
        if (randomSpawnpoint2 == 0)
        {
            key2.position = key2Spawn0.position;
        }
        else if (randomSpawnpoint2 == 1)
        {
            key2.position = key2Spawn1.position;
        }
        else if (randomSpawnpoint2 == 2)
        {
            key2.position = key2Spawn2.position;
        }
        else if (randomSpawnpoint2 == 3)
        {
            key2.position = key2Spawn3.position;
        }

        // Controls Key 3 spawn
        if (randomSpawnpoint3 == 0)
        {
            key3.position = key3Spawn0.position;
        }
        else if (randomSpawnpoint3 == 1)
        {
            key3.position = key3Spawn1.position;
        }
        else if (randomSpawnpoint3 == 2)
        {
            key3.position = key3Spawn2.position;
        }
        else if (randomSpawnpoint3 == 3)
        {
            key3.position = key3Spawn3.position;
        }

        waitTime += Time.deltaTime;

        if (waitTime >= 5f)
        {
            Destroy(gameObject);
        }
    }
}
