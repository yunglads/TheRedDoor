using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;
    public float waitTime;

    //public GameObject playerObject;
    Vector3 portalForward;
    Vector3 portalBackward;

    public GameObject portalForw;
    public GameObject portalBack;
    public BoxCollider portalCollider;
    public BoxCollider portal2Collider;
    public BoxCollider exitCollider;
    public BoxCollider exitCollider2;

    public Transform player;
    public GameObject playerObject;
    //public Transform reciever;
    private NavMeshAgent agent;
    public float timer;
    public float thinkTime;
    //public float lineOfSightAngle;

    public bool isWandering = false;
    public bool isChasing = false;
    //bool enemyIsOverlapping = false;
    public bool inArea1 = false;
    public bool inArea2 = false;
    public bool inArea3 = false;
    //public bool isSearching = false;
    //public bool playerHit = false;

    private Vector3 newPos;

    NoiseLevel noiseLevel;
    PlayerHealth health;
    

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
        timer = thinkTime;

        noiseLevel = GameObject.FindObjectOfType<NoiseLevel>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        player = playerObject.GetComponent<Transform>();

        portalForward = portalForw.transform.position;
        portalBackward = portalBack.transform.position;
        portalCollider.enabled = true;
        portal2Collider.enabled = false;
        //isWandering = false;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.deltaTime;

        /*if (enemyIsOverlapping)
        {
            Vector3 playerToPortal = gameObject.transform.position - reciever.transform.position;
            float dotProduct = Vector3.Dot(reciever.transform.up, playerToPortal);

            if (dotProduct < 0f)
            {
                float rotationDifference = Quaternion.Angle(reciever.transform.rotation, reciever.rotation);
                rotationDifference += 180;
                player.Rotate(Vector3.up, rotationDifference);

                Vector3 postionOffset = Quaternion.Euler(0f, rotationDifference, 0) * playerToPortal;
                player.position = reciever.position + postionOffset;

                enemyIsOverlapping = false;
            }
        }*/

        timer += Time.deltaTime;

        /*if (timer >= .2f)
        {
            isWandering = true;
        }

        if (timer >= wanderTimer && !isChasing)
        {
            newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            isWandering = false;
            //agent.SetDestination(newPos);
        }

        if (timer >= thinkTime && !isChasing)
        {
            agent.SetDestination(newPos);
            timer = 0;
        }*/

        //LineOfSight();
        Wander();

        if (noiseLevel.noiseLevel == 0 && isChasing)
        {
            isChasing = false;
            timer = 8;
        }

        /*if (teleporter.enemyPassedPortal)
        {
            //GetComponent<NavMeshAgent>().enabled = true;
            GetComponent<NavMeshAgent>().SetDestination(portalForward.position);
        }*/

        /*if (isSearching)
        {
            isWandering = false;
        }*/
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }

    /*void LineOfSight()
    {
        Vector3 targetDir = player.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);

        if (angle < lineOfSightAngle)
        {
            agent.SetDestination(player.position);
            //print("player in line of sight");
        }
    }*/

    void Wander()
    {
        if (timer >= .2f)
        {
            isWandering = true;
        }

        if (timer >= wanderTimer && !isChasing)
        {
            newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            isWandering = false;
            //agent.SetDestination(newPos);
        }

        if (timer >= thinkTime && !isChasing)
        {
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            //waitTime = 0f;
            portal2Collider.enabled = false;
            //print("portal 2 off");
            gameObject.GetComponent<NavMeshAgent>().Warp(portalForward);
            wanderTimer = 14f;
            /*if (waitTime >= 2f)
            {
                portal2Collider.enabled = true;
                print("portal 2 on");
            }

            if (waitTime >= 3f)
            {
                portalCollider.enabled = true;
                print("portal 1 on");
            }*/
            //enemyIsOverlapping = true;
        }

        if (other.tag == "Portal Back")
        {
            //waitTime = 0f;
            portalCollider.enabled = false;
            //print("portal 1 off");
            gameObject.GetComponent<NavMeshAgent>().Warp(portalBackward);
            wanderTimer = 14f;
            /*if (waitTime >= 2f)
            
                portalCollider.enabled = true;
                print("portal 1 on");
            }

            if (waitTime >= 3f)
            {
                portal2Collider.enabled = true;
                print("portal 2 on");
            }*/
            //enemyIsOverlapping = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && noiseLevel.noiseLevel >= 1)
        {
            isChasing = true;
            timer = 0;
            agent.destination = player.position;
            //print("Is Chasing");
        }

        /*if (other.tag == "Player" && noiseLevel.noiseLevel <= 0)
        {
            isChasing = false;
            timer = 0;
        }*/
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isChasing = false;
            timer = 12;
        }

        if (other.tag == "Exit Collider")
        {
            portal2Collider.enabled = true;
            portalCollider.enabled = false;
            //print("portal 2 on");
            exitCollider.enabled = false;
            exitCollider2.enabled = true;
        }

        if (other.tag == "Exit Collider 2")
        {
            portalCollider.enabled = true;
            portal2Collider.enabled = false;
            //print("portal 1 on");
            exitCollider.enabled = true;
            exitCollider2.enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Area 1")
        {
            inArea1 = true;
        }

        if (collision.gameObject.tag == "Area 2")
        {
            inArea2 = true;
        }

        if (collision.gameObject.tag == "Area 3")
        {
            inArea3 = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Area 1")
        {
            inArea1 = false;
        }

        if (collision.gameObject.tag == "Area 2")
        {
            inArea2 = false;
        }

        if (collision.gameObject.tag == "Area 3")
        {
            inArea3 = false;
        }
    }
}
