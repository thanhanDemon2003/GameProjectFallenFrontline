using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunSkinModel;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;
// using GunSkinList;

public class ApplySkin : MonoBehaviour
{
    public string prefabsFolderPath = "Assets/Resource/UI/Skins/Skin";
    public string gunImageFolderPath = "Assets/Resource/UI/Skins/Images";
    public GameObject conTent;
    public GameObject itemGunSkin;
    public Sprite anh;

    void Start()
    {
        getAllSkin();
    }
    void Update()
    {

    }
    async void getAllSkin()
    {
        GunSkinData Skins = await GunSkinApi.GetAllSkins();

        Debug.Log("Skins: " + Skins);
        foreach (GunSkinModel.GunSkin skin in Skins.data)
        {
            var id = skin._id;
            var name = skin.name;
            var color = skin.color;
            var percent = skin.percent;
            var price = skin.price;
            var category = skin.category;
            skin.PrefabPath = prefabsFolderPath + "/" + color;
            skin.image = gunImageFolderPath + "/" + name + ".png";


            Debug.Log("fullskin: " + skin.image);
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name;
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = price.ToString();
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[2].text = percent.ToString();
            var image = itemGunSkin.GetComponentsInChildren<Image>()[0];
            Texture2D tex = new(2, 2);
            tex.LoadImage(File.ReadAllBytes(skin.image));
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
            Debug.Log("image: " + image.sprite);
            var skinDataStorage = itemGunSkin.GetComponent<StorageData>();
            skinDataStorage.SkinData(id, skin.PrefabPath, price, percent);

            //itemGunSkin.GetComponent<Button>().onClick.AddListener(onClickData);
            
            var newSkin =  Instantiate(itemGunSkin, conTent.transform);
          newSkin.name = id;
            
        }
    }
    //public void onClickData()
    //{
    //    var skinData = itemGunSkin.GetComponent<StorageData>();
    //    var skinId = skinData.skinId;
    //    var pathModelSkin = skinData.pathModelSkin;
    //    var balance = skinData.blance;
    //    skinData.GetSkinData(skinId, pathModelSkin, balance);
    //    Debug.Log("skinId: " + skinId);
    //    Debug.Log("pathModelSkin: " + pathModelSkin);
    //    Debug.Log("balance: " + balance);
    //}
}

