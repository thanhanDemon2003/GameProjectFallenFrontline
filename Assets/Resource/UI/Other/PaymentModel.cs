using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PaymentModel
{
    [Serializable]
    public class PaymentData
    {
        public bool success;
        public Payment[] payment;
        public PaymentData(bool success, Payment[] payment)
        {
            this.success = success;
            this.payment = payment;
        }
    }
    [Serializable]
    public class Payment
    {
        public string _id;
        public string buyerName;
        public int amountPayment;
        public int orderCodePayment;
        public string methodPayment;
        public int dotCoint;
        public string statusPayment;
        public string idPlayer;
        public string description;
        public string Date;
        public Payment(string _id, string buyerName, int amountPayment, int orderCodePayment, string methodPayment, int dotCoint, string statusPayment, string idPlayer, string description, string Date)
        {
            this._id = _id;
            this.buyerName = buyerName;
            this.amountPayment = amountPayment;
            this.orderCodePayment = orderCodePayment;
            this.methodPayment = methodPayment;
            this.dotCoint = dotCoint;
            this.statusPayment = statusPayment;
            this.idPlayer = idPlayer;
            this.description = description;
            this.Date = Date;
        }

    }
}
