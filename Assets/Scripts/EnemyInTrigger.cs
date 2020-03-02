using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInTrigger : MonoBehaviour
{
    public GameObject enemy;
    public bool enemyGone = false;

    private void Update()
    {
        if (enemyGone)
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyGone = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyGone = true;
        }

        if (other.tag == "Player")
        {
            enemyGone = true;
        }
    }
}
