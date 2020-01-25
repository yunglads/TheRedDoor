using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCheck : MonoBehaviour
{
    public bool inArea1 = false;
    public bool inArea2 = false;
    public bool inArea3 = false;

    float waitTime;

    EnemyAI enemyAI;

    void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
    }

    void Update()
    {
        /*if (inArea2 && !enemyAI.inArea2)
        {
            waitTime += Time.deltaTime;
        }

        if (inArea2 && !enemyAI.inArea2 && waitTime >= 10f)
        {
            enemyAI.portal2Collider.enabled = true;
            waitTime = 0f;
        }

        if (inArea1 && !enemyAI.inArea1)
        {
            waitTime += Time.deltaTime;
        }

        if (inArea1 && !enemyAI.inArea1 && waitTime >= 10f)
        {
            enemyAI.portalCollider.enabled = true;
            waitTime = 0f;
        }*/
    }

    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Area 1")
        {
            inArea1 = true;
        }

        if (other.tag == "Area 2")
        {
            inArea2 = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Area 1")
        {
            inArea1 = false;
        }

        if (other.tag == "Area 2")
        {
            inArea2 = false;
        }
    }*/

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
