using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    public NavMeshSurface surface;
    public GameObject enemy;
    public GameObject player;
    public GameObject playerBot;
    public GameObject playerBot2;
    public GameObject playerBot3;
    public GameObject portal1;
    public GameObject portal2;
    public GameObject portal3;
    public GameObject portal4;

    public float waitTime = 0;

    bool navMeshBuilt = false;
    // Start is called before the first frame update
    void Start()
    {
        
        //surface.BuildNavMesh();
        enemy.SetActive(false);
        playerBot.SetActive(false);
        playerBot2.SetActive(false);
        playerBot3.SetActive(false);
        portal1.SetActive(false);
        portal2.SetActive(false);
        portal3.SetActive(false);
        portal4.SetActive(false);
        //player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshBuilt)
            return;

        waitTime += Time.deltaTime;

        if (waitTime >= 1f)
        {
            //navMeshBuilt = true;
            surface.BuildNavMesh();
        }

        if (waitTime >= 2f)
        {
            //surface.BuildNavMesh();
            enemy.SetActive(true);
            playerBot.SetActive(true);
            playerBot2.SetActive(true);
            playerBot3.SetActive(true);
            portal1.SetActive(true);
            portal2.SetActive(true);
            portal3.SetActive(true);
            portal4.SetActive(true);
            //player.SetActive(true);
            navMeshBuilt = true;
            //print("Mesh Built");
        }
    }
}
