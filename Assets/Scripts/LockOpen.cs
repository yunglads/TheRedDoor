using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOpen : MonoBehaviour
{
    AudioSource source;
    public AudioClip clip;
    bool newGamePlayed = false;
    bool continueGamePlayed = false;

    MainMenu mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu = FindObjectOfType<MainMenu>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenu.newGame && !newGamePlayed)
        {
            source.PlayOneShot(clip);
            newGamePlayed = true;
            //print("Play audio");
        }

        if (mainMenu.continueGame && !continueGamePlayed)
        {
            source.PlayOneShot(clip);
            continueGamePlayed = true;
            //print("Play audio");
        }
    }
}
