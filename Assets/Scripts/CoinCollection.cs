using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollection : MonoBehaviour
{
    [SerializeField] TMP_Text CoinText;
    private int coinCount = 0;
    [SerializeField] AudioSource coinCollectSFX;

    void Start()
    {
        coinCount = 0;
        CoinText.text = "X " + coinCount;
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
