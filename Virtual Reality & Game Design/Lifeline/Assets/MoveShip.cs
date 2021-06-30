using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody missile;
    public GameObject rightMissile;
    public GameObject leftMissile;
    Transform transform;
    Collider collider;
    float speed = 30f;
    float rotateTimer = 1f;
    Quaternion targetRotation;
    Quaternion originalRotation;
    bool right = false;
    float shootTimer = 0.25f;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    float enemyTimer = 5f;
    public static int sequence;
    void Start()
    {
        transform = GetComponent<Transform>();
        targetRotation = transform.rotation;
        originalRotation = transform.rotation;
        collider = GetComponent<Collider>();
        sequence = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Position: x: " + transform.position.x + ", y: " + transform.position.y + ", z: " + transform.position.z + ", Sequence: " + sequence);
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            targetRotation = originalRotation;
        else if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -60)
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
            targetRotation = Quaternion.AngleAxis(35, Vector3.forward);
            if(transform.position.x <= -58)
                targetRotation = originalRotation;
            else
                targetRotation = Quaternion.AngleAxis(35, Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 60)
        {
            transform.position += Vector3.right * Time.deltaTime * speed;
            if (transform.position.x >= 58)
                targetRotation = originalRotation;
            else
                targetRotation = Quaternion.AngleAxis(-35, Vector3.forward);
        }
        shootTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (shootTimer <= 0)
            {
                if (right)
                {
                    Instantiate(missile, leftMissile.transform.position, transform.rotation);
                    right = false;
                }
                else
                {
                    Instantiate(missile, rightMissile.transform.position, transform.rotation);
                    right = true;
                }
                shootTimer = 0.25f;
            }
        }
        if (Input.anyKey == false)
        {
            if (originalRotation != targetRotation)
                targetRotation = originalRotation;
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * rotateTimer * Time.deltaTime);
        enemyTimer -= Time.deltaTime;
        if(enemyTimer <= 0)
        {
            spawnEnemy();
            enemyTimer = 10f;
        }
    }
    void spawnEnemy()
    {
        if(sequence == 0)
        {
            GameObject e1 = Instantiate(enemy1);
            e1.transform.position = new Vector3(-60f, 0, 60f);
            GameObject e2 = Instantiate(enemy1);
            e2.transform.position = new Vector3(-60f, 0, 72f);
        }
        else if(sequence == 1)
        {
            GameObject e1 = Instantiate(enemy2);
            e1.transform.position = new Vector3(48f, 0, 60f);
            GameObject e2 = Instantiate(enemy2);
            e2.transform.position = new Vector3(48f, 0, 72f);
            GameObject e3 = Instantiate(enemy2);
            e3.transform.position = new Vector3(48f, 0, 84f);
        }
        else if(sequence == 2)
        {
            GameObject e1 = Instantiate(enemy3);
            e1.transform.position = new Vector3(60f, 0, 60f);
            GameObject e2 = Instantiate(enemy3);
            e2.transform.position = new Vector3(60f, 0, 72f);
        }
        sequence = Random.Range(0, 3);
    }
}
