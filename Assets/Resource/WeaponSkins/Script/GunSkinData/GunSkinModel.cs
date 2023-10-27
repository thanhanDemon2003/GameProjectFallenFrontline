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
        public string id;
        public string name;
        public string color;
        public string PrefabPath;
        public string category;
        public int price;
        public int percent;
        public int status;

        public GunSkin(string id, string name, string color, string PrefabPath, string category, int price, int percent, int status)
        {
            this.id = id;
            this.name = name;
            this.color = color;
            this.PrefabPath = PrefabPath;
            this.category = category;
            this.price = price;
            this.percent = percent;
            this.status = status;
        }

    }
}