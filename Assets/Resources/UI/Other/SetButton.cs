using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class SetButton : MonoBehaviour
{
    public GameObject contenTransaction;
    public GameObject contenPayment;
    //public GameObject contenHistory;
    public Button btnPayment;
    public Button btnTransaction;
    public TextMeshProUGUI txtHeader;

    public void SetButtonPayment()
    {
        txtHeader.text = "Payment";
        btnPayment.GetComponent<Image>().color = Color.gray;
        btnTransaction.GetComponent<Image>().color = Color.white;
        btnTransaction.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0.8f);
        contenPayment.SetActive(true);
        contenTransaction.SetActive(false);
        //contenHistory.SetActive(false);
    }
    public void SetButtonTransaction()
    {
        txtHeader.text = "Transaction";
        btnPayment.GetComponent<Image>().color = Color.white;
        btnPayment.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0.8f);
        btnTransaction.GetComponent<Image>().color = Color.gray;
        contenPayment.SetActive(false);
        contenTransaction.SetActive(true);
        
        //contenHistory.SetActive(false);
    }
}
