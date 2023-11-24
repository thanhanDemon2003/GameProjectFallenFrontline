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

    public void SkinData(string id, string pathPrefap, int price, int percent)
    {

        skinId = id;
        pathModelSkin = pathPrefap;
        if(percent == 0)
        {
            blance = price;
        }
        else
        {
            blance = (price / 100 * percent);

        }

    }
   public void GetSkinData(string skinId, string pathModelSkin, int balance)
    {
            skinId = skinId;
        pathModelSkin = pathModelSkin;
        blance = balance;
    }
}
