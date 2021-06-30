using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    Quaternion originalRotation;
    Quaternion targetRotation;
    Vector3 original;
    Vector3 target;
    float rotateTimer = 1f;
    void Start()
    {
        transform = GetComponent<Transform>();
        /*originalRotation = transform.rotation;
        targetRotation = transform.rotation;
        original = transform.localPosition;
        target = transform.localPosition;*/
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            targetRotation = Quaternion.AngleAxis(-45, Vector3.forward);
            target = new Vector3(original.x - 1f, original.y, original.z);

        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * rotateTimer * Time.deltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, target, 10 * rotateTimer * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.Space) == false && Input.anyKey == false)
        {
            if (originalRotation != targetRotation)
                targetRotation = originalRotation;
            if (original != target)
                target = original;
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            var dir = collision.contacts[0].point - transform.position;
            dir = dir.normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(dir * 1000f);
        }    
    }
}
