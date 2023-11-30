using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TransactionModel;
using PlayerModel;
using System;
using TMPro;
public class ApplyTransaction : MonoBehaviour
{
    public GameObject itemTransaction;
    public Transform contentTransaction;
    // Start is called before the first frame update
    void Start()
    {
        var player = File.ReadAllText(Application.persistentDataPath + "/Player.json");
        Data data = JsonUtility.FromJson<PlayerModel.Data>(player);
        ApplyTransactionData(data._id);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private async void ApplyTransactionData(string idPlayer)
    {
        
        TransactionData transactionData = await ApiOther.GetAllTransactionModel(idPlayer);
        foreach (TransactionModel.Transaction transaction in transactionData.data)
        {
            var timeGoble = transaction.Date;
            DateTime dateTime = DateTime.Parse(timeGoble);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            TimeZoneInfo vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            DateTime vietnamDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, vietnamZone);
            string timeResult = vietnamDateTime.ToString("dd/MM/yyyy HH:mm");
            Debug.Log(timeResult);
            itemTransaction.GetComponentsInChildren<TextMeshProUGUI>()[0].text = timeResult;
            itemTransaction.GetComponentsInChildren<TextMeshProUGUI>()[2].text = transaction.nameSkin;
            itemTransaction.GetComponentsInChildren<TextMeshProUGUI>()[4].text = transaction.category;
            itemTransaction.GetComponentsInChildren<TextMeshProUGUI>()[6].text = transaction.price.ToString();
            Instantiate(itemTransaction, contentTransaction);
        }

    }
}
