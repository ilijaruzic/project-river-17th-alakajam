using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideCroc : MonoBehaviour
{
    private Vector3 pos;
    private Vector3 dis = new Vector3(0.5f, 0, 0);
    [SerializeField] private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        BoxCollider collider = GetComponent<BoxCollider>();
        transform.position = Vector3.Lerp(pos - dis, pos + dis, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
