using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] AudioSource MenuClick;
    public string currentLevel;
    public bool isMute;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        PlayClickSound();
        // Ovo bi trebalo da radi :((
        //SceneManager.LoadScene(currentLevel);

    }

    public void MuteToggle()
    {
        isMute = !isMute;
        // Dodati gasenje audio source-ova, audioSource referenca pa .volume = 0;
    }

    public void RestartLevel()
    {
        // Isot SceneManager.LoadScene(currentLevel)
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
