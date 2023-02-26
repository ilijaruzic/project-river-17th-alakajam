using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCroc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        transform.Translate(Vector3.left * Time.deltaTime * 10f);
        if (false) // ? transform.position.x ?? xx)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10f);
        }
    }
}
