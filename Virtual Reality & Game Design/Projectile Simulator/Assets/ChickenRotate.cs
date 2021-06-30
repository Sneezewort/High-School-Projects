using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ChickenRotate : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    Rigidbody rb;
    Boolean isShot = false;

    void Start()
    {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
            transform.RotateAround(transform.position, new Vector3(1, 0, 0), 100 * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.RotateAround(transform.position, new Vector3(-1, 0, 0), 100 * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isShot == false)
        {
            isShot = true;
            rb.useGravity = true;
            rb.AddForce(rb.transform.forward * 20f, ForceMode.Impulse);
        }
    }
}
