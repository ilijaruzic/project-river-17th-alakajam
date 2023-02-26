using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchTerrains : MonoBehaviour
{
    [SerializeField] Mesh groundMesh;
    [SerializeField] Mesh riverMesh;

    [SerializeField] AudioSource splashSFX;
    [SerializeField] AudioSource landSFX;

    [SerializeField] TMP_Text RiverEnterText;

    public bool isSailing;
    private bool isInArea;
    [SerializeField] BoxCollider[] collidersToInvert;

    [SerializeField] Vector3 riverPoint;
    [SerializeField] Vector3 groundPoint;

    // Start is called before the first frame update
    void Start()
    {
        isSailing = false;
        isInArea = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isInArea)
        {
            Debug.Log("Pressed");
            if (isSailing)
            {
                foreach (var collider in collidersToInvert)
                {
                    if (collider.gameObject.CompareTag("RiverColliders"))
                    {
                        collider.enabled = true;
                    }
                    else
                    {
                        collider.enabled = false;
                    }
                }
                
                GetComponent<MeshFilter>().sharedMesh = groundMesh;
                
                landSFX.Play();
                //transform.position = groundPoint;
                isSailing = false;
            }
            else
            {
                foreach (var collider in collidersToInvert)
                {
                    if (collider.gameObject.CompareTag("GroundColliders"))
                    {
                        collider.enabled = true;
                    }
                    else
                    {
                        collider.enabled = false;
                    }
                }

                GetComponent<MeshFilter>().sharedMesh = riverMesh;

                splashSFX.Play();
                //transform.position = riverPoint;
                isSailing = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "SetSail" || other.name == "SetGround")
        {
            isInArea = true;
            RiverEnterText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "SetSail" || other.name == "SetGround")
        {
            isInArea = false;
            RiverEnterText.gameObject.SetActive(false);
        }
    }
}
