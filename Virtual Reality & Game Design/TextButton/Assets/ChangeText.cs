using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    // Start is called before the first frame update
    Button button;
    public Text text;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(TextChange);
        //text = GameObject.Find("Canvas/Title").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void TextChange()
    {
        text.text = "Text Changed";
    }
}
