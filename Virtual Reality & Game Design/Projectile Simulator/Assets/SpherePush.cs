using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePush : MonoBehaviour
{
    // Start is called before the first frame update
    float force = 5f;
    Rigidbody rb;
    Boolean isShot = false;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && isShot == false)
        {
            isShot = true;
            rb = GetComponent<Rigidbody>();
            rb.AddForce(rb.transform.up * force, ForceMode.Impulse);
        }
    }
}
