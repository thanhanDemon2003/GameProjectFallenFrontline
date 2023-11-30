using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

namespace TransactionModel
{
    [Serializable]
    public class TransactionData {
        public bool success;
        public Transaction[] data;
        public TransactionData(bool success, Transaction[] data)
        {
            this.success = success;
            this.data = data;
        }
    }
    [Serializable]
    public class Transaction
    {
        public string _id;
        public string id_Player;
        public string id_GunSkin;
        public string nameSkin;
        public string category;
        public int price;
        public string Date;
        public Transaction(string _id, string id_Player, string id_GunSkin, string nameSkin, string category, int price, string Date)
        {
            this._id = _id;
            this.id_Player = id_Player;
            this.id_GunSkin = id_GunSkin;
            this.nameSkin = nameSkin;
            this.category = category;
            this.price = price;
            this.Date = Date;
        }
    }




}
