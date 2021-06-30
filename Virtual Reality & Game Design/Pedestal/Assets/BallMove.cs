using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Start is called before the first frame update
    float force = 10f;
    Rigidbody rb;
    Boolean space;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var value = Input.GetAxis("Horizontal");
        Debug.Log("Input - " + value);
        if (Input.GetKeyDown("Space"))
            space = true;
    }
    private void FixedUpdate()
    {
        if(space)
        {
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            space = false;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * force * Input.GetAxis("Horizontal"), ForceMode.Force);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(Vector3.right * force * Input.GetAxis("Horizontal"), ForceMode.Force);
        }
    }
}
