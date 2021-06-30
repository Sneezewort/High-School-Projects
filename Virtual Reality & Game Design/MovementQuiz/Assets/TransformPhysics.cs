using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TransformPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float force = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var value = Input.GetAxis("Horizontal");
        Debug.Log("Input - " + value);
    }
    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * -1);
        rb.AddForce(new Vector3(0,0,1));
        rb.AddForce(Vector3.forward * force * -1, ForceMode.Force);
        rb.AddForceAtPosition(Vector3.forward * 2f * -1, new Vector3(0, 0 , 1), ForceMode.Force);
    }
}
