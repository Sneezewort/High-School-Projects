using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Transform transform;
    public GameObject leg;
    bool jump = true;
    Quaternion originalRotation;
    Quaternion targetRotation;
    Vector3 original;
    Vector3 target;
    float rotateTimer = 1.5f;
    float secondTimer = 1.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        originalRotation = leg.transform.rotation;
        targetRotation = leg.transform.rotation;
        original = leg.transform.localPosition;
        target = leg.transform.localPosition;
        Debug.Log("Original: " + original.x + ", " + original.y + ", " + original.z);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && jump)
        {
            rb.AddForce(new Vector3(0f, 60f, 0f), ForceMode.Impulse);
            jump = false;
        }
        if (transform.position.y > 1.6)
            jump = false;
        else
            jump = true;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(new Vector3(-3f, 0f, 0f), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(new Vector3(3f, 0f, 0f), ForceMode.Impulse);
        }
        if(Input.GetKey(KeyCode.Space))
        {
            targetRotation = Quaternion.AngleAxis(-120, Vector3.forward);
            target = new Vector3(original.x - 1f, original.y, original.z);

        }
        leg.transform.rotation = Quaternion.Lerp(leg.transform.rotation, targetRotation, 10 * rotateTimer * Time.deltaTime);
        //leg.transform.localPosition = Vector3.Lerp(leg.transform.position, target, 10 * rotateTimer * Time.deltaTime);
       
        if (Input.GetKey(KeyCode.Space) == false && Input.anyKey == false)
        {
            if (originalRotation != targetRotation)
            {
                targetRotation = originalRotation;
            }
            if (original != target)
                target = original;
            
            leg.gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            secondTimer -= Time.deltaTime;
        }
        if(secondTimer <= 0f)
        {
            secondTimer = 1.5f;
            leg.transform.rotation = Quaternion.Euler(0, 0, 0);
            leg.gameObject.GetComponent<MeshRenderer>().enabled = false;
            leg.gameObject.GetComponent<Rigidbody>().detectCollisions = false;

        }
        if (leg.transform.eulerAngles.z <= 1f && leg.transform.eulerAngles.z >= -1f)
            leg.gameObject.GetComponent<MeshRenderer>().enabled = false;
        else if (Input.GetKey(KeyCode.Space))
        {
            leg.gameObject.GetComponent<MeshRenderer>().enabled = true;
            leg.gameObject.GetComponent<Rigidbody>().detectCollisions = true;
        }
        //Debug.Log("Target: " + target.x + ", " + target.y + ", " + target.z);
        //Debug.Log("" + leg.transform.eulerAngles.z);
        //Debug.Log("" + jump);
        Debug.Log("" + secondTimer);
    }
}
