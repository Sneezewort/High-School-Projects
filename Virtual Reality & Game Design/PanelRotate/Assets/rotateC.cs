using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateC : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    public Transform transform;
    public Text text;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(clockwise);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void clockwise()
    {
        transform.Rotate(0f, 0f, -1f, Space.Self);
        text.text = transform.rotation.eulerAngles.z + " Degrees";
    }
}
