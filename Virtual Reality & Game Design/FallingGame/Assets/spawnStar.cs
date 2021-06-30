using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnStar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject star;
    Transform transform;
    float time = 3f;
    Vector3 position; 
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            position = new Vector3(Random.Range(-3, 5), transform.position.y, Random.Range(-5, 5));
            time = 3f;
            Instantiate(star, position, transform.rotation);
        }
    }
}
