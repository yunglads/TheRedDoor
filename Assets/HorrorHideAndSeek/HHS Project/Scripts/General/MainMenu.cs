﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [Header("Settings")]
    [Tooltip("Name of the level scene name")]
    public string levelSceneName;
    [Tooltip("Continue button gameobject")]
    public Button continueButton;
    [Tooltip("Slider to controll volume")]
    public Slider volumeSlider;
    [Tooltip("Slider to controll sensitivity")]
    public Slider sensitivitySlider;
    [HideInInspector]
    public bool newGame = false;
    [HideInInspector]
    public bool continueGame = false;

    public void Awake()
    {
        Time.timeScale = 1.0f;
        //continueButton.interactable = false;

        if(PlayerPrefs.HasKey("Sensitivity"))
        {
            sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity");
        }else
        {
            sensitivitySlider.value = 50f;
            PlayerPrefs.SetFloat("Sensitivity",50f);
        }

        if (PlayerPrefs.HasKey("Volume"))
        {
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            volumeSlider.value = 1f;
            PlayerPrefs.SetFloat("Volume", 1f);
        }


        if (PlayerPrefs.HasKey("HasSaveGame"))
        {
            if(PlayerPrefs.GetInt("HasSaveGame") == 1)
            {
                continueButton.interactable = true;
            }
        }
    }

    

    public void StartGame(int state)
    {
        if (state == 1)
        {
           StartCoroutine(ContinueGame());
           continueGame = true;
        }

        if (state == 0)
        {
            StartCoroutine(StartNewGame());
            newGame = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Configure()
    {   
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
    }

    public IEnumerator ContinueGame()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetString("SceneName", "New Game");
        PlayerPrefs.SetInt("LoadGame", 1);
        SceneManager.LoadScene("LoadScene");
        //continueGame = true;
    }

    public IEnumerator StartNewGame()
    {
        yield return new WaitForSeconds(2f);
        PlayerPrefs.SetString("SceneName", "New Game");
        PlayerPrefs.SetInt("LoadGame", 0);
        SceneManager.LoadScene("LoadScene");
        //newGame = true;
    }
}
