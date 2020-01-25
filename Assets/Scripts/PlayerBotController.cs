using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBotController : MonoBehaviour
{
    public Transform wayPoint1, wayPoint2, wayPoint3, wayPoint4;
    public int pickWP;
    public float backUpTimer;
    public bool enteredWP = false;
    bool isRunning;
    public bool canBeCaught = false;
    public GameObject deadWP;
    public Vector3 deadPos;
    float waitTime;

    AreaCheck areaCheck;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        areaCheck = FindObjectOfType<AreaCheck>();
        agent = GetComponent<NavMeshAgent>();
        pickWP = -1;
        backUpTimer = 0f;
        deadPos = deadWP.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SearchingWayPoints();

        if (!canBeCaught)
        {
            waitTime += Time.deltaTime;
            transform.position = deadPos;
            if (waitTime >= 1f)
            {
                gameObject.SetActive(false);
                waitTime = 0f;
                return;
            }
        }
    }

    void SearchingWayPoints()
    {
        if (pickWP == -1 && !enteredWP)
        {
            pickWP = Random.Range(0, 4);
            print(pickWP);
        }
        if (enteredWP)
        {
            pickWP = -1;
            //enteredWP = false;
        }

        if (pickWP == 0)
        {
            agent.SetDestination(wayPoint1.position);
        }
        if (pickWP == 1)
        {
            agent.SetDestination(wayPoint2.position);
        }
        if (pickWP == 2)
        {
            agent.SetDestination(wayPoint3.position);
        }
        if (pickWP == 3)
        {
            agent.SetDestination(wayPoint4.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WayPoint")
        {
            enteredWP = true;
        }

    }

    void OnTriggerStay(Collider other)
    {
        backUpTimer += Time.deltaTime;
        if (other.tag == "WayPoint" && backUpTimer >= 5f)
        {
            enteredWP = false;
            backUpTimer = 0f;
            pickWP = -1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "WayPoint")
        {
            backUpTimer = 0f;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Area 1")
        {
            canBeCaught = true;
        }
        if (collision.gameObject.tag == "Area 2")
        {
            canBeCaught = true;
        }
        if (collision.gameObject.tag == "Area 3")
        {
            canBeCaught = true;
        }
    }
}
