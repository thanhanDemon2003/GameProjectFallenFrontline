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
    public GameObject contentReward;
    public Button btnPayment;
    public Button btnTransaction;
    public Button btnReward;
    public TextMeshProUGUI txtHeader;

    public void SetButtonPayment()
    {
        txtHeader.text = "Payment";
        btnPayment.GetComponent<Image>().color = Color.gray;
        btnPayment.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0.8f);
        btnTransaction.GetComponent<Image>().color = Color.white;
        btnTransaction.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1f);
        btnPayment.interactable = false;
        btnReward.interactable = true;
        btnTransaction.interactable = true;
        btnReward.GetComponent<Image>().color = Color.white;
        btnReward.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1f);
        contenPayment.SetActive(true);
        contenTransaction.SetActive(false);
        contentReward.SetActive(false);
    }
    public void SetButtonTransaction()
    {
        txtHeader.text = "Transaction";
        btnPayment.GetComponent<Image>().color = Color.white;
        btnPayment.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1f);
        btnTransaction.GetComponent<Image>().color = Color.gray;
        btnTransaction.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0.8f);
        btnTransaction.interactable = false;
        btnReward.interactable = true;
        btnPayment.interactable = true;
        btnReward.GetComponent<Image>().color = Color.white;
        btnReward.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1f);
        contenPayment.SetActive(false);
        contenTransaction.SetActive(true);
        contentReward.SetActive(false);

    }
    public void SetButtonReward()
    {
        txtHeader.text = "Reward";
        btnPayment.GetComponent<Image>().color = Color.white;
        btnPayment.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1f);
        btnTransaction.GetComponent<Image>().color = Color.white;
        btnTransaction.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 1f);
        btnReward.GetComponent<Image>().color = Color.gray;
        btnReward.interactable = false;
        btnPayment.interactable = true;
        btnTransaction.interactable = true;
        btnReward.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, 0.8f);
        contenPayment.SetActive(false);
        contenTransaction.SetActive(false);
        contentReward.SetActive(true);

    }
}
