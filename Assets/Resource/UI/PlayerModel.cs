using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data.Common;
namespace PlayerModel
{
    [Serializable]
    public class Player
    {
        public bool success;
        public string notification;
        public Data data;
        public string url;
        public string stt;
        public string token;
        public string method;
        public string name;

        Player(bool success, string notification, Data Data, string url, string stt, string token, string method, string name)
        {
            this.success = success;
            this.notification = notification;
            this.data = data;
            this.url = url;
            this.stt = stt;
            this.token = token;
            this.method = method;
            this.name = name;
        }
    }
    [Serializable]
    public class Data
    {
        public string _id;
        public string name;
        public string fb_id;
        public string id_discord;
        public string token;
        public string method;
        public string balance;
        public Skins[] wardrobe;
        public Data(string _id, string name, string fb_id, string id_discord, string token, string method, string balance, Skins[] wardrobe)
        {
            this._id = _id;
            this.name = name;
            this.fb_id = fb_id;
            this.id_discord = id_discord;
            this.token = token;
            this.method = method;
            this.balance = balance;
            this.wardrobe = wardrobe;
        }
    }

    [Serializable]
    public class Skins
    {
        public string id;
        public string gunskinId;
        public string nameSkin;
        public string color;
        public string category;
        public Skins(string id, string gunskinId, string nameSkin, string color, string category)
        {
            this.id = id;
            this.gunskinId = gunskinId;
            this.nameSkin = nameSkin;
            this.color = color;
            this.category = category;
        }
    }



}