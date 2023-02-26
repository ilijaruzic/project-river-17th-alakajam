using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        transform.RotateAround(collider.bounds.center, Vector3.up, Time.deltaTime * 50f);
    }
}
