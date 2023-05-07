using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
public class Storage: MonoBehaviour
{
    public List<Deposit> deposits = new List<Deposit>();
    



    public void SaveXML()
    {
        XmlElement elem;

        XmlDocument doc = new XmlDocument();
        XmlNode rootNode = doc.CreateElement("Deposit");
        doc.AppendChild(rootNode);
        for(int i=0;i<deposits.Count;i++)
        {
        elem = doc.CreateElement("SumDeposit");
        elem.SetAttribute("SumDeposit",deposits[i].sumDeposit.ToString());
        rootNode.AppendChild(elem);

        elem = doc.CreateElement("PercentDeposit");
        elem.SetAttribute("PercentDeposit",deposits[i].percentDeposit.ToString()+"%");
        rootNode.AppendChild(elem);        

        elem = doc.CreateElement("TimeDeposit");
        elem.SetAttribute("TimeDeposit",deposits[i].timeDeposit.ToString() +" "+ deposits[i].timeTypeDeposit);
        rootNode.AppendChild(elem);         

        elem = doc.CreateElement("PeriodDeposit");
        elem.SetAttribute("PeriodDeposit",deposits[i].periodDeposit);
        rootNode.AppendChild(elem); 

        elem = doc.CreateElement("Revenue");
        elem.SetAttribute("Revenue",deposits[i].Revenue.ToString());
        rootNode.AppendChild(elem); 
        }
        doc.Save("C:/deposit.xml");
    }

}
