using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownLanguage : MonoBehaviour
{
    public MainScript _main;
    public List<string> Russian = new List<string>();
    public List<string> English = new List<string>();
    public Dropdown _drop;
    private void Awake() {
        _main = GameObject.Find("Canvas").GetComponent<MainScript>();
        _drop = GetComponent<Dropdown>();
        ChangeLanguageDrop();
    }
    public void ChangeLanguageDrop()
    {
        if(_main.language){ 
            _drop.ClearOptions();
            _drop.AddOptions(Russian);
        }
        else{
            _drop.ClearOptions();
            _drop.AddOptions(English);
        }
    }
    
}
