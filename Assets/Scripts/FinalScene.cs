using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalScene : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public GameObject endScene;

    bool inTrigger = false;
    bool animStarted = false;
    float waitTime;
    float endTime;
    // Start is called before the first frame update
    void Start()
    {
        enemy.SetActive(false);
        player.GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger)
        {
            waitTime += Time.fixedDeltaTime;
        }

        if (waitTime >= 3f && inTrigger)
        {
            player.GetComponent<Animator>().enabled = true;
            animStarted = true;
        }

        if (animStarted)
        {
            endTime += Time.deltaTime;
        }

        if (endTime >= 8f)
        {
            endScene.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemy.SetActive(true);
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<PlayerController>().cameraAnimation = null;
            inTrigger = true;
        }
    }
}
