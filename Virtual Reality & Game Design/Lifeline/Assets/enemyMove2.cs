using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove2 : MonoBehaviour
{
    Transform transform;
    float speed = 8f;
    ParticleSystem explode;
    int step = 0;
    float p11 = 4f;
    float p12 = 11f;
    // Start is called before the first frame update
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
            p11 -= Time.deltaTime;
            transform.position += Vector3.back * Time.deltaTime * speed;
            if (p11 <= 0)
            {
                step = 1;
                p11 = 4f;
            }
        }
        else if (step == 1)
        {
            p12 -= Time.deltaTime;
            transform.position += Vector3.left * Time.deltaTime * speed;
            if (p12 <= 0)
            {
                step = 2;
                p12 = 12f;
            }
        }
        else if (step == 2)
        {
            transform.position += Vector3.back * Time.deltaTime * speed;
            if (transform.position.z <= -30)
                Destroy(transform.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Missile(Clone)")
        {
            explode.Play();
            Destroy(this.gameObject, 0.5f);
        }
    }
}
