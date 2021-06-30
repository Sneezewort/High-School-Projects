using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMove : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    float speed = 5f;
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * speed;
        transform.Rotate(0, 100*Time.deltaTime, 0, Space.Self);
    }
}
