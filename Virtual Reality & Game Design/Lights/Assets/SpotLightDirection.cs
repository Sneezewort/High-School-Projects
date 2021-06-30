using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightDirection : MonoBehaviour
{
    Transform transform;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 5f, transform.localEulerAngles.z);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y - 5f, transform.localEulerAngles.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x - 5f, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x + 5f, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }
}
