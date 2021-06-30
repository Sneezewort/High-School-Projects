using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator playerAnimator;
    Rigidbody2D rid;
    public static bool dead = false;
    public GameObject enemy;
    Animator enemyAnimator;
    float health = 10f;
    public GameObject healthBar;
    float coolDown = 0;
    BoxCollider2D box;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rid = GetComponent<Rigidbody2D>();
        rid.freezeRotation = true;
        enemyAnimator = enemy.GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (Input.GetKeyDown("space") && coolDown < 0)
            {
                playerAnimator.SetTrigger("attack");
                coolDown = 100f;
            }
            coolDown -= 1f;
            if (Input.GetKey("right"))
            {
                transform.localScale = new Vector3(-1f, 1, 1);
                transform.position = new Vector3(transform.position.x + .05f, transform.position.y, transform.position.z);
                playerAnimator.SetBool("walkBool", true);
            }
            else if (Input.GetKey("left"))
            {
                transform.localScale = new Vector3(1f, 1, 1);
                transform.position = new Vector3(transform.position.x - .05f, transform.position.y, transform.position.z);
                playerAnimator.SetBool("walkBool", true);
            }
            else
                playerAnimator.SetBool("walkBool", false);
            if (Input.GetKey("r"))
            {
                Debug.Log("t");
                dead = true;
                playerAnimator.enabled = false;
                this.GetComponent<EyesBlink>().enabled = false;
                for (int i = this.transform.GetChild(0).gameObject.transform.GetChild(0).transform.childCount - 1; i != -1; i--)
                {
                    GameObject part = this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;
                    Destroy(part, 4 + Random.Range(0.5f, 0.5f));
                    ejectParts(part);
                }
                for (int i = this.transform.GetChild(0).gameObject.transform.childCount - 1; i != -1; i--)
                {
                    GameObject part = this.transform.GetChild(0).transform.GetChild(0).gameObject;
                    Destroy(part, 5 + Random.Range(0.5f, 0.5f));
                    ejectParts(part);
                }
                Destroy(this.gameObject, 6 + Random.Range(0.5f, 0.5f));
            }
        }
        else
        {
            playerAnimator.enabled = false;
            box.enabled = false;
            Destroy(this);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy Weapon" && enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            health--;
            float remain = health / 10f;
            if (remain < 0)
                remain = 0;
            healthBar.transform.localScale = new Vector2(remain, healthBar.transform.localScale.y);
            if (health <= 0)
            {
                dead = true;
                enemyAnimator.enabled = false;
                for (int i = this.transform.GetChild(0).gameObject.transform.GetChild(0).transform.childCount - 1; i != -1; i--)
                {
                    GameObject part = this.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;
                    Destroy(part, 4 + Random.Range(0.5f, 0.5f));
                    ejectParts(part);
                }
                for (int i = this.transform.GetChild(0).gameObject.transform.childCount - 1; i != -1; i--)
                {
                    GameObject part = this.transform.GetChild(0).transform.GetChild(0).gameObject;
                    Destroy(part, 5 + Random.Range(0.5f, 0.5f));
                    ejectParts(part);
                }
                Destroy(this.gameObject, 6 + Random.Range(0.5f, 0.5f));
            }
        }
    }
    void ejectParts(GameObject part)
    {
        part.tag = null;
        Rigidbody2D rb2d = part.GetComponent<Rigidbody2D>();
        if (part.GetComponent<BoxCollider2D>())
            part.GetComponent<BoxCollider2D>().enabled = true;
        if (!rb2d)
            rb2d = part.AddComponent<Rigidbody2D>();
        var vec = 5 * new Vector2(Random.Range(-20, 20), Random.Range(-2, 2));
        part.transform.parent = null;
        rb2d.AddForce(vec, ForceMode2D.Impulse);
    }

}
