using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TVController : MonoBehaviour
{
    VideoPlayer videoPlayer;
    public GameObject videoPlane;

    private void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlane.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            videoPlane.SetActive(true);
            videoPlayer.Play();
        }
    }
}
