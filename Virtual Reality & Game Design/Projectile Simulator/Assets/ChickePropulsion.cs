using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChickePropulsion : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    public GameObject chicken;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("x: " + transform.position.x + "y: "+transform.position.y + "z: "+transform.position.z);
            Instantiate(chicken, transform.position, transform.rotation);
        }
    }
}
