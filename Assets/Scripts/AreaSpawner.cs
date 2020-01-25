using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{
    public GameObject area1, area2, area3, area4, area5, area6;
    public GameObject area1Ground, area2Ground, area3Ground, area4Ground, area5Ground, area6Ground;
    public Transform areaSpawn1, areaSpawn2, areaSpawn3;

    int randomSpawn1, randomSpawn2, randomSpawn3;
    bool area1On, area2On, area3On, area4On, area5On, area6On = false;

    float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        randomSpawn1 = Random.Range(0, 6);
        randomSpawn2 = Random.Range(0, 6);
        randomSpawn3 = Random.Range(0, 6);

        //SpawnAreas();
        //DestroyAreas();
    }

    // Update is called once per frame
    void Update()
    {
        //print(randomSpawn1);
        //print(randomSpawn2);
        //print(randomSpawn3);

        SpawnAreas();
        DestroyAreas();

        if (randomSpawn1 == randomSpawn2)
        {
            randomSpawn1++;
        }
        if (randomSpawn1 == randomSpawn3)
        {
            randomSpawn1++;
        }
        if (randomSpawn1 >= 6)
        {
            randomSpawn1 = 0;
        }

        if (randomSpawn2 == randomSpawn1)
        {
            randomSpawn2++;
        }
        if (randomSpawn2 == randomSpawn3)
        {
            randomSpawn2++;
        }
        if (randomSpawn2 >= 6)
        {
            randomSpawn2 = 0;
        }

        if (randomSpawn3 == randomSpawn1)
        {
            randomSpawn3++;
        }
        if (randomSpawn3 == randomSpawn2)
        {
            randomSpawn3++;
        }
        if (randomSpawn3 >= 6)
        {
            randomSpawn3 = 0;
        }

        waitTime += Time.deltaTime;

        if (waitTime >= 5f)
        {
            Destroy(gameObject);
        }
    }

    void SpawnAreas()
    {
        if (randomSpawn1 == 0)
        {
            area1.transform.position = areaSpawn1.position;
            area1On = true;
            area1Ground.tag = "Area 1";
        }
        if (randomSpawn1 == 1)
        {
            area2.transform.position = areaSpawn1.position;
            area2On = true;
            area2Ground.tag = "Area 1";
        }
        if (randomSpawn1 == 2)
        {
            area3.transform.position = areaSpawn1.position;
            area3On = true;
            area3Ground.tag = "Area 1";
        }
        if (randomSpawn1 == 3)
        {
            area4.transform.position = areaSpawn1.position;
            area4On = true;
            area4Ground.tag = "Area 1";
        }
        if (randomSpawn1 == 4)
        {
            area5.transform.position = areaSpawn1.position;
            area5On = true;
            area5Ground.tag = "Area 1";
        }
        if (randomSpawn1 == 5)
        {
            area6.transform.position = areaSpawn1.position;
            area6On = true;
            area6Ground.tag = "Area 1";
        }

        if (randomSpawn2 == 0)
        {
            area1.transform.position = areaSpawn2.position;
            area1On = true;
            area1Ground.tag = "Area 2";
        }
        if (randomSpawn2 == 1)
        {
            area2.transform.position = areaSpawn2.position;
            area2On = true;
            area2Ground.tag = "Area 2";
        }
        if (randomSpawn2 == 2)
        {
            area3.transform.position = areaSpawn2.position;
            area3On = true;
            area3Ground.tag = "Area 2";
        }
        if (randomSpawn2 == 3)
        {
            area4.transform.position = areaSpawn2.position;
            area4On = true;
            area4Ground.tag = "Area 2";
        }
        if (randomSpawn2 == 4)
        {
            area5.transform.position = areaSpawn2.position;
            area5On = true;
            area5Ground.tag = "Area 2";
        }
        if (randomSpawn2 == 5)
        {
            area6.transform.position = areaSpawn2.position;
            area6On = true;
            area6Ground.tag = "Area 2";
        }

        if (randomSpawn3 == 0)
        {
            area1.transform.position = areaSpawn3.position;
            area1On = true;
            area1Ground.tag = "Area 3";
        }
        if (randomSpawn3 == 1)
        {
            area2.transform.position = areaSpawn3.position;
            area2On = true;
            area2Ground.tag = "Area 3";
        }
        if (randomSpawn3 == 2)
        {
            area3.transform.position = areaSpawn3.position;
            area3On = true;
            area3Ground.tag = "Area 3";
        }
        if (randomSpawn3 == 3)
        {
            area4.transform.position = areaSpawn3.position;
            area4On = true;
            area4Ground.tag = "Area 3";
        }
        if (randomSpawn3 == 4)
        {
            area5.transform.position = areaSpawn3.position;
            area5On = true;
            area5Ground.tag = "Area 3";
        }
        if (randomSpawn3 == 5)
        {
            area6.transform.position = areaSpawn3.position;
            area6On = true;
            area6Ground.tag = "Area 3";
        }
    }

    void DestroyAreas()
    {
        if (!area1On && waitTime >= 3f)
        {
            area1.SetActive(false);
        }

        if (!area2On && waitTime >= 3f)
        {
            area2.SetActive(false);
        }

        if (!area3On && waitTime >= 3f)
        {
            area3.SetActive(false);
        }

        if (!area4On && waitTime >= 3f)
        {
            area4.SetActive(false);
        }

        if (!area5On && waitTime >= 3f)
        {
            area5.SetActive(false);
        }

        if (!area6On && waitTime >= 3f)
        {
            area6.SetActive(false);
        }
    }
}
