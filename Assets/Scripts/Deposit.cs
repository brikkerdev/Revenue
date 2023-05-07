using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Deposit : MonoBehaviour
{
    public float sumDeposit;

    public float percentDeposit;

    public float timeDeposit;
    public string timeTypeDeposit;
    public int timeTypeValue;

    public float periodDepositValue;
    public string periodDeposit;

    public bool ownAccount;
    
    public float Revenue;

    public Text _Name;
    public Text _Sum;
    public Text _Percent;
    public Text _Time;
    public Text _Revenue;

    public MainScript _main;
    private void Start() {
        _main = GameObject.Find("Canvas").GetComponent<MainScript>();
        sumDeposit=_main.sumDeposit;
        percentDeposit=_main.percentDeposit;
        timeDeposit=_main.timeDeposit;
        timeTypeDeposit=_main.timeTypeDeposit;
        timeTypeValue=_main.timeTypeValue;
        periodDepositValue=_main.periodDepositValue;
        periodDeposit=_main.periodDeposit;
        ownAccount=_main.ownAccount;
        Revenue=_main.Revenue;
        if(_main.language){ 
            _Name.text="Вклад "+_main.nameInt;
            _Sum.text = sumDeposit.ToString()+"₽";
            _Revenue.text= Mathf.Round(Revenue) + "₽";
        }
        else{ 
            _Name.text="Deposite "+_main.nameInt;
            _Sum.text = sumDeposit.ToString()+"$";
            _Revenue.text= Mathf.Round(Revenue) + "$";
        }
        _Percent.text = percentDeposit+"%";
        _Time.text = timeDeposit+" "+timeTypeDeposit;

    }
}
