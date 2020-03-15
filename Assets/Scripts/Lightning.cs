using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    public float waitTime;
    public int randomTime;
    Light lightning;
    // Start is called before the first frame update
    void Start()
    {
        lightning = gameObject.GetComponent<Light>();
        lightning.enabled = false;
        randomTime = Random.Range(10, 25);
    }

    // Update is called once per frame
    void Update()
    {
        waitTime += Time.fixedDeltaTime;
        if (waitTime >= randomTime)
        {
            lightning.enabled = true;
        }

        if (waitTime >= randomTime + 1f)
        {
            waitTime = 0f;
        }

        if (waitTime < randomTime)
        {
            lightning.enabled = false;
        }
    }
}
