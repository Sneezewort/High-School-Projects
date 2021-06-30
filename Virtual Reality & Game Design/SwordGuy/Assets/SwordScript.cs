using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator a;
    Transform transform;
    bool faceLeft = true;
    Rigidbody2D rb;
    Vector3 vel = Vector3.zero;
    float speed = 5f;
    float horizontal = 0f;
    void Start()
    {
        a = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;
        if(Input.GetKeyDown("space"))
        {
            a.SetTrigger("attackTrigger");
        }
        if(Input.GetKey("d"))
        {
            if (faceLeft)
            {
                faceLeft = false;
                Flip();
            }
            Vector3 target = new Vector2(horizontal * 10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, target, ref vel, 0.05f);
        }
        if(Input.GetKey("a"))
        {
            if(!faceLeft)
            {
                faceLeft = true;
                Flip();
            }
            Vector3 target = new Vector2(horizontal * 10f, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, target, ref vel, 0.05f);
        }
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
