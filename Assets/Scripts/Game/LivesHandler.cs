using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LivesHandler : MonoBehaviour
{
    [SerializeField] TMP_Text HeartText;
    private int livesCount;
    [SerializeField] AudioSource liveLostSFX;

    void Start()
    {
        livesCount = 3;
        HeartText.text = "X " + livesCount;
    }

    public void UpdateLivesCount()
    {
        if (livesCount > 0)
        {
            liveLostSFX.Play();
            --livesCount;
            HeartText.text = "X " + livesCount;
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // stones as well?
        if (other.CompareTag("Croc"))
        {
            UpdateLivesCount();
        }
    }
}
