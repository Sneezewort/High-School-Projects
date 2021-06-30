using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcePush : MonoBehaviour
{
    // Start is called before the first frame update
    float force = 20f;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * force, ForceMode.Impulse);
    }
    // Update is called once per frame
    void Update()
    {
            
    }
}
