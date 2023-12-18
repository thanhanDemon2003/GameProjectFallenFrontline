using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor   ;

public class StorageData : MonoBehaviour
{
   public string skinId;
   public string pathModelSkin;
   public int blance;
   public string category;
   public string pathImgSkin;
   public string nameSkin;
    public int priceOld;

    public void SkinData(string id, string pathPrefap, int price, int percent, string category, string pathImgSkin, string name)
    {

        skinId = id;
        pathModelSkin = pathPrefap;
        if(percent == 0)
        {
            blance = price;
        }
        else
        {
            blance = price - (price / 100 * percent);

        }
        this.category = category;
        this.pathImgSkin = pathImgSkin;
        nameSkin = name;
        priceOld = price;

    }
   public void GetSkinData(string skinId, string pathModelSkin, int balance, string category, string pathImgSkin, string name, int priceOld)
    {
        this.skinId = skinId;
        this.pathModelSkin = pathModelSkin;
        blance = balance;
        this.category = category;
        this.pathImgSkin = pathImgSkin;
        nameSkin = name;
        this.priceOld = priceOld;
    }
}
