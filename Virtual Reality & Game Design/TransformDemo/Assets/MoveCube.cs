using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveCube : MonoBehaviour
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
        UnityEngine.Debug.Log("Time passed is" + timer);
        //transform.Translate(0.25f*Vector3.forward);
        //transform.Translate(Vector3.forward * Time.deltaTime);
        if(Input.GetKey(KeyCode.Space))
            transform.Translate(Vector3.forward * Time.deltaTime);
        UnityEngine.Debug.Log(transform.position.z);
    }
}
