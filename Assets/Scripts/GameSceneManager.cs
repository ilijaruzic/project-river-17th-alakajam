using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] AudioSource MenuClick;
    public string currentLevel;
    public bool isMute;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }

    public void StartGame()
    {
        PlayClickSound();
        currentLevel = "Level1";
        CurrentLevel();
    }

    public void Level(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void CurrentLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

    public void MuteToggle()
    {
        isMute = !isMute;
        // Dodati gasenje audio source-ova, audioSource referenca pa .volume = 0;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void HowTo()
    {
        SceneManager.LoadScene("HowTo");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void QuitGame()
    {
        PlayClickSound();
        // Trebalo bi da se doda delay preko korutine ili druge funkcije da bi se sacekalo pustanje zvuka
        Application.Quit();
    }

    private void PlayClickSound()
    {
        // nesto sa yield return + WaitForSeconds(0.5)
    }
}
