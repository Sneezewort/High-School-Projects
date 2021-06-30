using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove3 : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    float speed = 8f;
    ParticleSystem explode;
    int step = 0;
    float p31 = 7f;
    float p32 = 15f;

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
            p31 -= Time.deltaTime;
            transform.position += Vector3.back * Time.deltaTime * speed;
            if (p31 <= 0)
            {
                step = 1;
                p31 = 7f;
            }
        }
        else if (step == 1)
        {
            p32 -= Time.deltaTime;
            transform.position += Vector3.left * Time.deltaTime * speed;
            if (p32 <= 0)
            {
                step = 2;
                p32 = 16f;
            }
        }
        else if (step == 2)
        {
            transform.position += Vector3.forward * Time.deltaTime * speed;
            if (transform.position.z >= 70)
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
