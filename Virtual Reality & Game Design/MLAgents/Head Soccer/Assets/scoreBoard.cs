using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour
{
    public static int redScore = 0;
    public static int blueScore = 0;
    public Text redText;
    public Text blueText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        redText.text = "Red: " + redScore;
        blueText.text = "Blue: " + blueScore;
    }
}
