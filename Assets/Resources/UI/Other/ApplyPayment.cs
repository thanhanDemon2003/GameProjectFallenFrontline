using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using PlayerModel;
using System;
using TMPro;
using PaymentModel;

public class ApplyPayment : MonoBehaviour
{
    public GameObject itemPayment;
    public Transform contentPayment;
    // Start is called before the first frame update
    void Start()
    {
        var player = File.ReadAllText(Application.persistentDataPath + "/Player.json");
        Data data = JsonUtility.FromJson<Data>(player);
        ApplyPaymentData(data._id);
        Debug.Log(data._id);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private async void ApplyPaymentData(string idPlayer)
    {
        Debug.Log(idPlayer + "nè");

        PaymentData paymentData = await ApiOther.GetAllPaymentModel(idPlayer);
        Debug.Log(paymentData);
        foreach (Payment payment in paymentData.payment)
        {
            var timeGoble = payment.Date;
            DateTime dateTime = DateTime.Parse(timeGoble);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            TimeZoneInfo vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            DateTime vietnamDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, vietnamZone);
            string timeResult = vietnamDateTime.ToString("dd/MM/yyyy HH:mm");
            itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[0].text = timeResult;
            itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[2].text = payment.methodPayment.ToString();
            itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[4].text = payment.amountPayment.ToString() + " - VND";
            itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[6].text = payment.dotCoint.ToString();
            itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[8].text = payment.statusPayment;
            if (payment.statusPayment == "CANCELLED")
            {
                itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[8].color = Color.red;
            }
            else if(payment.statusPayment == "PAID")
            {
                itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[8].color = Color.green;
            }
            else
            {
                itemPayment.GetComponentsInChildren<TextMeshProUGUI>()[8].color = Color.yellow;
            }
            Instantiate(itemPayment, contentPayment);


        }
    }
}
