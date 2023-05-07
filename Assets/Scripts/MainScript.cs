using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainScript : MonoBehaviour
{
    public float sumDeposit=0;

    public float percentDeposit=0;

    public float timeDeposit=0;
    public string timeTypeDeposit;
    public int timeTypeValue=0;

    public float periodDepositValue=0;
    public string periodDeposit;

    public bool ownAccount=true;

    public float Revenue=0;

    public GameObject _prefab;
    public Vector3 nextPos;

    public int nameInt=0;

    public Scrollbar _depositsScroll;
    public Scrollbar _peroidScroll;
    public DropDownLanguage _drop;
    public Deposit _currentDeposit;
    public Transform depositParent;
    public GameObject settingsPanel;
    public GameObject createPanel;

    public bool settings;
    public bool create;
    public bool language;

    public string[] every;
    private void Start() {
        AccountOwnSet(true);
        settingsPanel.SetActive(true);
        createPanel.SetActive(true);
        settingsPanel.SetActive(false);
        createPanel.SetActive(false);
    }
    public void SetValues()
    {
        sumDeposit = float.Parse(GameObject.Find("sumDepositValue").GetComponent<Text>().text);
        percentDeposit = float.Parse(GameObject.Find("percentDepositValue").GetComponent<Text>().text);
        timeDeposit = float.Parse(GameObject.Find("timeDepositValue").GetComponent<Text>().text);
        timeTypeDeposit = GameObject.Find("timeTypeDepositValue").GetComponent<Text>().text;
        if(language){
            switch (timeTypeDeposit)
            {
            case "Дней":
                timeTypeValue=1;
                break;
            case "Месяцев":
                timeTypeValue=30;
                break;
            case "Лет":
                timeTypeValue=365;
                break;
            default:
                timeTypeValue=1;
                break;
            }
        }
        else{
            switch (timeTypeDeposit)
            {
            case "Days":
                timeTypeValue=1;
                break;
            case "Months":
                timeTypeValue=30;
                break;
            case "Years":
                timeTypeValue=365;
                break;
            default:
                timeTypeValue=1;
                break;
            }           
        }
        PeriodCalculate();
    }
    public void Calculate()
    {
        _depositsScroll.value=0;
        SetValues();
        Revenue = sumDeposit*percentDeposit*(timeDeposit*timeTypeValue/365);
        _currentDeposit =  Instantiate(_prefab,nextPos,Quaternion.identity,GameObject.Find("GameObject").transform).GetComponent<Deposit>();
        gameObject.GetComponent<Storage>().deposits.Add(_currentDeposit);
        
        nextPos = new Vector3(nextPos.x+300,nextPos.y,10);
        nameInt++;
        _depositsScroll.size=Mathf.Clamp(6f/nameInt,0,1);
    }
    public void PeriodCalculate()
    {

        periodDepositValue = _peroidScroll.value;
        if(periodDepositValue<0.3f) periodDepositValue = 0;
        else if(periodDepositValue>=0.3f && periodDepositValue<=0.7f) periodDepositValue = 0.5f;
        else if(periodDepositValue>0.7f) periodDepositValue = 1;
        switch (periodDepositValue)
        {
            case 0f:
                periodDeposit=every[0];
                break;
            case 0.5f:
                periodDeposit=every[1];
                break;
            case 1f:
                periodDeposit=every[2];
                break;
            default:
                periodDeposit=every[0];
                break;
        }
        GameObject.Find("periodValue").GetComponent<Text>().text = periodDeposit;
    }
    public void AccountOwnSet(bool owner)
    {
        ownAccount = owner;
    }
    private void Update() {
        depositParent.position = new Vector3(-_depositsScroll.value*300*nameInt,0,0);
    }
    public void SettingsPanel()
    {
        if(settings){
            settings=false;
            settingsPanel.SetActive(false);
        }
        else{
            settings=true;
            settingsPanel.SetActive(true);
        }
    }
    public void ChangeLanguage()
    {
        if(language){
            language=false;
            every[0]="Every-Month";
            every[1]="Every-Quarter";
            every[2]="Every-Year";
        }
        else
        {
            language=true;
            every[0]="Ежемесячно";
            every[1]="Ежеквартально";
            every[2]="Ежегодно";  
        }
        createPanel.SetActive(true);
        _drop.ChangeLanguageDrop();
        PeriodCalculate();
        if(!create) createPanel.SetActive(false);
    }
    public void CreateBool(bool _create)
    {
        create = _create;
        settingsPanel.SetActive(false);
    }

}
