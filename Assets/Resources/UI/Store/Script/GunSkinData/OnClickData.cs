using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using PlayerModel;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.InputManagerEntry;
public class OnClickData : MonoBehaviour
{
    public ApplySkin applySkin;
    private string PathFile;
    public Button mySkin;
    public GameObject buySkin;
    public GameObject ThongBao;

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
        var category = skinData.category;
        var pathImgSkin = skinData.pathImgSkin;
        var name = skinData.nameSkin;
        skinData.GetSkinData(skinId, pathModelSkin, balance, category, pathImgSkin, name);
        buySkin.SetActive(true);
        var image = buySkin.GetComponentsInChildren<Image>()[1];
        Texture2D tex = new(2, 2);
        image.sprite = Resources.Load<Sprite>(pathImgSkin);
        buySkin.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name + " - " + category;
        buySkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = balance.ToString();
        buySkin.GetComponentsInChildren<Button>()[0].onClick.AddListener(() => onBuySkin(skinId, balance));
        buySkin.GetComponentsInChildren<Button>()[0].onClick.AddListener(() => buySkin.SetActive(false));
    }
    public void onBuySkin(string skinId, int balance)
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(PathFile));
        string id = data._id;
        int balancePlayer = data.balance;
        if (balance > balancePlayer)
        {
            ThongBao.SetActive(true);
            ThongBao.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "You don't have enough money to buy this skin";
            Debug.Log("Không đủ tiền");
            return;
        }
        else
        {
            StartCoroutine(resApiBuy(id, skinId));
            Debug.Log("Mua thành công");
        }

    }
    IEnumerator resApiBuy(string id, string skinId)
    {
        yield return GunSkinApi.BuySkin(id, skinId);
        if (GunSkinApi.BuySkin(id, skinId) != null)
        {
            succesBuy();
        }
        else
        {
            failBuy();
        }
    }

    public void succesBuy()
    {
        mySkin.interactable = false;
        mySkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "Owned";
        mySkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.gray;

    }
    public void failBuy()
    {
        ThongBao.SetActive(true);
        ThongBao.GetComponentsInChildren<TMPro.TextMeshProUGUI>()[0].text = "Error, please check your network or balance again";

    }
}
