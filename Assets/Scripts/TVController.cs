using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVController : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public GameObject videoPlane;
    Collider trigger;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlane.SetActive(false);
        trigger = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            videoPlane.SetActive(true);
            videoPlayer.Play();
            Destroy(trigger);
        }
    }
}
