using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    float time = 10f;
    Text timer;
    void Start()
    {
        timer = GetComponent<Text>();
        timer.text = time.ToString("0.00") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time > 0f)
            timer.text = time.ToString("0.00") + "s";
        else
            timer.text = "0s";
    }
}
