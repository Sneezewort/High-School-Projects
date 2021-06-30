using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float decelRate = 50f;
    public GameObject missile;
    ParticleSystem flame;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        flame = GetComponent<ParticleSystem>();
        flame.startRotation = -90f;
        flame.Play();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.forward * 50, ForceMode.Force);
        if (rb.velocity.x < 0)
            rb.AddForce(Vector3.left * rb.velocity.x * decelRate * Time.deltaTime);
        else if(rb.velocity.x > 0)
            rb.AddForce(Vector3.left * rb.velocity.x * decelRate * Time.deltaTime);
        if (rb.position.z > 70 && rb != null)
            Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "StarSparrow5(Clone)" || collision.gameObject.name == "StarSparrow7(Clone)" || collision.gameObject.name == "StarSparrow10(Clone)")
        { 
            Destroy(this.gameObject);
            flame.Stop();
        }
    }
}
