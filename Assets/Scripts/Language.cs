using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public MainScript _main;
    public string Russian;
    public string English;
    public Text text;
    private void Start() {
        _main = GameObject.Find("Canvas").GetComponent<MainScript>();
        text = gameObject.GetComponent<Text>();
    }
    private void FixedUpdate() {
        if(_main.language) text.text=Russian;
        else text.text=English;
    }
}
