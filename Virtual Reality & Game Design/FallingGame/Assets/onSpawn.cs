using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class onSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    Transform transform;
    float speed = 2f;
    public ParticleSystem part;
    ParticleSystem.Particle[] particles;
    Color partColor;
    void Start()
    {
        transform = GetComponent<Transform>();
        part = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[part.particleCount];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * speed;
        if (transform.position.y <= -10)
        {
            Destroy(transform.gameObject);
        }
        /*for (float alpha = 255; alpha > 0; alpha -= 50)
        {
            for (int i = 0; i < particles.Length; i++)
            {
                partColor = particles[i].GetCurrentColor(part);
                partColor.a = alpha;
                particles[i].color = partColor;
            }
        }*/
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Catcher")
        {
           
            Destroy(this.gameObject);
            ScoreBoard.score += 1;

        }
    }
}
