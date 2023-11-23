// GunSkin.cs
using UnityEngine;
using System.Collections;

namespace GunSkinModel
{
    [System.Serializable]
    public class GunSkinData
    {
        public bool success;
        public string notification;
        public GunSkin[] data;
    }
    [System.Serializable]
    public class GunSkin
    {
        public string _id;
        public string name;
        public string color;
        public string PrefabPath;
        public string image;
        public string category;
        public int price;
        public int percent;
        public int status;

        public GunSkin(string _id, string name, string color, string PrefabPath,string image, string category, int price, int percent, int status)
        {
            this._id = _id;
            this.name = name;
            this.color = color;
            this.PrefabPath = PrefabPath;
            this.image = image;
            this.category = category;
            this.price = price;
            this.percent = percent;
            this.status = status;
        }

    }
}