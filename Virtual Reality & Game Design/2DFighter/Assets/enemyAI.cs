using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Animator playerAnimator;
    Animator enemyAnimator;
    bool dead = false;
    float health = 3;
    public GameObject healthBar;
    float speed = 0.005f;
    float coolDown = 0f;
    BoxCollider2D box;

    void Start()
    {
        playerAnimator = player.GetComponent<Animator>();
        enemyAnimator = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (player.transform.position.x > this.transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1, 1);
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
                enemyAnimator.SetBool("walk", true);
            }
            else if (player.transform.position.x < this.transform.position.x)
            {
                transform.localScale = new Vector3(1f, 1, 1);
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
                enemyAnimator.SetBool("walk", true);
            }
            else
            {
                enemyAnimator.SetBool("walk", false);
            }
            if (Mathf.Abs(player.transform.position.x - this.transform.position.x) < 3 && coolDown < 0)
            {
                if (!(playerControl.dead))
                {
                    enemyAnimator.SetTrigger("attack");
                    coolDown = 300f;
                }
            }
            coolDown -= 1f;
        }
        else
        {
            enemyAnimator.enabled = false;
            box.enabled = false;
            Destroy(this);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Weapon" && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            health--;
            float remain = health / 3f;
            if (remain < 0)
                remain = 0;
            healthBar.transform.localScale = new Vector2(remain, healthBar.transform.localScale.y);
            if(health <= 0)
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
