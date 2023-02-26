using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockMechanic : MonoBehaviour
{
    [SerializeField] TMP_Text RockText;
    private int rockCount;
    [SerializeField] AudioSource rockThrowSFX;
    [SerializeField] AudioSource rockCollectSFX;

    void Start()
    {
        rockCount = 0;
        RockText.text = "X " + rockCount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowRock();
        }
    }

    public void ThrowRock()
    {
        if (rockCount > 0)
        {
            rockThrowSFX.Play();
            rockCount--;
            RockText.text = "X " + rockCount;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            rockCount++;
            Destroy(other.gameObject);
            RockText.text = "X " + rockCount;
            rockCollectSFX.Play();
        }
    }
}
