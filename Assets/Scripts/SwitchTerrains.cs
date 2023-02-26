using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTerrains : MonoBehaviour
{
    [SerializeField] Mesh groundMesh;
    [SerializeField] Mesh riverMesh;

    [SerializeField] AudioSource splashSFX;
    [SerializeField] AudioSource landSFX;

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
                /*
                 * 
                 *  public GameObject yourGameObject; //assign your gameobject from the inspector here
 MeshFilter yourMesh;
 
 yourMesh = yourGameObject.GetComponent<MeshFilter>();
 yourMesh.sharedMesh = Resources.Load<Mesh>("your mesh name here");
                 * 
                 */
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "SetSail" || other.name == "SetGround")
        {
            isInArea = false;
        }
    }
}
