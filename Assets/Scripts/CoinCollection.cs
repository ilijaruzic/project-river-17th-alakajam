using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] TMP_Text CoinText;
    private int coinCount = 0;
    [SerializeField] private int maxCoins = 5;
    [SerializeField] AudioSource coinCollectSFX;

    void Start()
    {
        coinCount = 0;
        CoinText.text = "X " + coinCount;
    }

    void Update()
    {
        if (coinCount == maxCoins)
        {
            SceneManager.LoadScene("Victory");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            CoinText.text = "X " + coinCount;
            coinCollectSFX.Play();
        }
    }
}
