using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickData : MonoBehaviour
{
    public static StorageData storageData;

public void onClickData()
    {
        var skinData = GetComponent<StorageData>();
        var skinId = skinData.skinId;
        var pathModelSkin = skinData.pathModelSkin;
        var balance = skinData.blance;
        skinData.GetSkinData(skinId, pathModelSkin, balance);
        Debug.Log("skinId: " + skinId);
        Debug.Log("pathModelSkin: " + pathModelSkin);
        Debug.Log("balance: " + balance);
    }
}
