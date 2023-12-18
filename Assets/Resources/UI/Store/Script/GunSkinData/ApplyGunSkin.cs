using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunSkinModel;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using Unity.VisualScripting;
using PlayerModel;
// using GunSkinList;

public class ApplySkin : MonoBehaviour
{
    public string prefabsFolderPath;
    public string gunImageFolderPath;
    public string FilePathGunSkin;
    public GameObject conTent;
    public GameObject itemGunSkin;
    public GameObject buySkin;
    public GameObject ThongBao;

    void Start()
    {   prefabsFolderPath = "UI/Skins/Skin";
        gunImageFolderPath = "UI/Skins/Images";
        FilePathGunSkin = Application.persistentDataPath + "/player.json";
        getAllSkin();
    }
    void Update()
    {

    }
    async void getAllSkin()
    {
        string json = File.ReadAllText(FilePathGunSkin);
        PlayerModel.Data dataPlayer = JsonUtility.FromJson<PlayerModel.Data>(json);
        Skins[] ownedGunSkins = dataPlayer.wardrobe;

        GunSkinData dataSkins = await GunSkinApi.GetAllSkins(); 
        foreach (GunSkinModel.GunSkin skin in dataSkins.data)
        {
            bool found = false;
            var id = skin._id;
            var name = skin.name;
            var color = skin.color;
            var percent = skin.percent;
            var price = skin.price;
            var status = skin.status;
            Debug.Log("status" + status);
            skin.PrefabPath = prefabsFolderPath + "/" + color;
            skin.image = gunImageFolderPath + "/" + color;

            Debug.Log(skin.image);
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name;
            var image = itemGunSkin.GetComponentsInChildren<Image>()[0];
            image.sprite = Resources.Load<Sprite>(skin.image);
            var saler = itemGunSkin.GetComponentsInChildren<RawImage>()[1];
            foreach (Skins ownedSkin in ownedGunSkins)
            {
                if (ownedSkin.gunskinId == skin._id)
                {

                    Debug.Log("trùng nè" + ownedSkin.gunskinId + "&&&" + skin._id);
                    itemGunSkin.GetComponent<Button>().enabled = false;
                    itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[0].text = ownedSkin.nameSkin;
                    itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "Owned";
                    itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.gray;
                    saler.enabled = false;
                    Instantiate(itemGunSkin, conTent.transform);
                    found = true;
                   
                }
            }
            if (found)
            {
                continue;
            }
            if(percent == 0 && status != 0)
            {
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = price.ToString();
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.black;
                saler.enabled = false;
                itemGunSkin.GetComponent<Button>().enabled = true;
            }
            else if(status == 0)
            {
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "stop selling";
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.blue;
                saler.enabled = false;
                itemGunSkin.GetComponent<Button>().enabled = false;
            }
            else
            {
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = (price - (price/100*percent)).ToString() ;
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.red;
                saler.enabled = true;
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[2].text = "sale "+ percent.ToString() + "%";
                itemGunSkin.GetComponent<Button>().enabled = true;

            }
            var skinDataStorage = itemGunSkin.GetComponent<StorageData>();
            skinDataStorage.SkinData(id, skin.PrefabPath, price, percent, skin.category, skin.image, name);
            OnClickData onClickData = itemGunSkin.GetComponent<OnClickData>();
            onClickData.buySkin = buySkin;
            onClickData.ThongBao = ThongBao;
            var newSkin =  Instantiate(itemGunSkin, conTent.transform);
          newSkin.name = id;

            
        }
    }
 
}

