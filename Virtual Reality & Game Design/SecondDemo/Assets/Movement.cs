using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("Time passed: " + timer);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.down * Time.deltaTime);
        transform.Translate(Vector3.forward * 0.5f*Time.deltaTime);

    }
}
