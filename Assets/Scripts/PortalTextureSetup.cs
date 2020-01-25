using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;
    public Material cameraMatA;
    public Material cameraMatB;

    public float waitTime;

    //public GameObject grannyOriginal;
    //public GameObject grannyClone1;

    PortalTeleporter teleporter;
    EnemyAI enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = FindObjectOfType<EnemyAI>();
        teleporter = FindObjectOfType<PortalTeleporter>();

        //grannyOriginal.SetActive(true);
        //grannyClone1.SetActive(false);

        if (camera1.targetTexture != null)
        {
            camera1.targetTexture.Release();
        }
        camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatB.mainTexture = camera1.targetTexture;

        if (camera2.targetTexture != null)
        {
            camera2.targetTexture.Release();
        }
        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatA.mainTexture = camera2.targetTexture;
    }

    /*void Update()
    {
        //waitTime += Time.deltaTime;
        if (teleporter.playerIsOverlapping)
        {
            //waitTime = 0f;
        }

        if (teleporter.portalEntered && enemyAI.inSight)
        {
            waitTime += Time.deltaTime;
        }

        if (waitTime >= 1f)
        {
            grannyOriginal.SetActive(false);
            grannyClone1.SetActive(true);
            waitTime = 0f;
            print("New granny spawned");
            teleporter.portalEntered = false;
        }
    }*/
}
