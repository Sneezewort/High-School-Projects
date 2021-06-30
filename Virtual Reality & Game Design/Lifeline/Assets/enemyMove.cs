using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    float speed = 8f;
    ParticleSystem explode;
    int step = 0;
    float p01 = 7f;
    float p02 = 15f;
    
    void Start()
    {
        transform = GetComponent<Transform>();
        explode = GetComponent<ParticleSystem>();
        explode.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 0)
        {
            p01 -= Time.deltaTime;
            transform.position += Vector3.back * Time.deltaTime * speed;
            if (p01 <= 0)
            {
                step = 1;
                p01 = 7f;
            }
        }
        else if(step == 1)
        {
            p02 -= Time.deltaTime;
            transform.position += Vector3.right * Time.deltaTime * speed;
            if (p02 <= 0)
            {
                step = 2;
                p02 = 16f;
            }
        }
        else if(step == 2)
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
            if (transform.position.z >= 70)
                Destroy(transform.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Missile(Clone)")
        {
            explode.Play();
            Destroy(this.gameObject, 0.5f);
        }
    }
}
