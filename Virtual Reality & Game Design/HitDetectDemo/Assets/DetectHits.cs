using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHits : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask hitLayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            Collider2D[] hitStuff;
            hitStuff = Physics2D.OverlapCircleAll(transform.position, 5, hitLayer);
            //Debug.Log("We hit something");
            for (int i = 0; i < hitStuff.Length; i++)
            {
                Debug.Log(hitStuff[i].gameObject.name);
                Debug.Log(hitStuff[i]);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 5);
    }
}
