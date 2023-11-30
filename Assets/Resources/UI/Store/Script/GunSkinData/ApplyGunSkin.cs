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

    void Start()
    {   prefabsFolderPath = "UI/Skins/Skin";
        gunImageFolderPath = "Assets/Resources/UI/Skins/Images";
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
            skin.PrefabPath = prefabsFolderPath + "/" + color;
            skin.image = gunImageFolderPath + "/" + color + ".png";

            Debug.Log(skin.image);
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name;
            var image = itemGunSkin.GetComponentsInChildren<Image>()[0];
            Texture2D tex = new(2, 2);
            tex.LoadImage(File.ReadAllBytes(skin.image));
            image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));

            foreach (Skins ownedSkin in ownedGunSkins)
            {
                if (ownedSkin.gunskinId == skin._id)
                {

                    Debug.Log("trùng nè" + ownedSkin.gunskinId + "&&&" + skin._id);
                    itemGunSkin.GetComponent<Button>().enabled = false;
                    itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[0].text = ownedSkin.nameSkin;
                    itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = "Owned";
                    itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.gray;
                    Instantiate(itemGunSkin, conTent.transform);
                    found = true;
                   
                }
            }
            if (found)
            {
                continue;
            }
            if(percent == 0)
            {
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = price.ToString();
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.black;
            }
            else
            {
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = (price - (price/100*percent)).ToString() ;
                itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].color = Color.red;

            }
            itemGunSkin.GetComponent<Button>().enabled = true;
            var skinDataStorage = itemGunSkin.GetComponent<StorageData>();
            skinDataStorage.SkinData(id, skin.PrefabPath, price, percent, skin.category, skin.image, name);
            OnClickData onClickData = itemGunSkin.GetComponent<OnClickData>();
            onClickData.buySkin = buySkin;
            var newSkin =  Instantiate(itemGunSkin, conTent.transform);
          newSkin.name = id;

            
        }
    }
 
}

