using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    // Start is called before the first frame update
    float forceAmount;
    Rigidbody rb;
    void Start()
    {
        forceAmount = 4.0f;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //do not put any physics here
        //rb.AddForce(transform.forward);
        //Debug.Log(rb.velocity.z);
        var value = Input.GetAxis("Horizontal");
        Debug.Log("Input - " + value);
    }
    private void FixedUpdate()
    {
        //rb.AddForce(transform.forward);
        //rb.AddForce(new Vector3(0, 0, 1));
        //rb.AddForce(Vector3.forward * forceAmount, ForceMode.Force);
    }
}
