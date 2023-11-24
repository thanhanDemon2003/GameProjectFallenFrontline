using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using PlayerModel;
public class OnClickData : MonoBehaviour
{
    private string PathFile;

    private void Awake()
    {
        PathFile = Application.persistentDataPath + "/Player.json";
    }
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
    public void onBuySkin()
    {
        var skinData = GetComponent<StorageData>();
        var skinId = skinData.skinId;
        var pathModelSkin = skinData.pathModelSkin;
        var balance = skinData.blance;
        skinData.GetSkinData(skinId, pathModelSkin, balance);
        Debug.Log("skinId: " + skinId);
        Debug.Log("pathModelSkin: " + pathModelSkin);
        Debug.Log("balance: " + balance);
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(PathFile));
        string id = data._id;
        int balancePlayer = data.balance;
        if (balance > balancePlayer)
        {
            Debug.Log("Không đủ tiền");
            return;
        }
        StartCoroutine(GunSkinApi.BuySkin(id, skinId));
    }

}
