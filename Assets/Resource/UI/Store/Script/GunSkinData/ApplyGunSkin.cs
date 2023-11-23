using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunSkinModel;
using UnityEngine.UI;
using TMPro;
// using GunSkinList;

public class ApplySkin : MonoBehaviour
{
    public string prefabsFolderPath = "Assets/Resource/UI/Skins/Skin/";
    public string gunImageFolderPath = "Assets/Resource/UI/Skins/Images/";
    public GameObject conTent;
    public GameObject itemGunSkin;


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
            skin.image = gunImageFolderPath + "/" + name+".png";
            //Debug.Log("id: " + id);
            //Debug.Log("name: " + name);
            //Debug.Log("Skin: " + skin.PrefabPath);
            //Debug.Log("img: " + skin.image);
            //Debug.Log("fullskin: " + skin);
            
             Instantiate(itemGunSkin, conTent.transform);
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name;
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[1].text = price.ToString();
            itemGunSkin.GetComponentsInChildren<TextMeshProUGUI>()[2].text = percent.ToString();
            itemGunSkin.GetComponentsInChildren<SpriteRenderer>()[1].sprite = Resources.Load<Sprite>(skin.image);
            Debug.Log("vị trí" + itemGunSkin.GetComponentsInChildren<SpriteRenderer>()[0] + itemGunSkin.GetComponentsInChildren<SpriteRenderer>()[1]);

            itemGunSkin.GetComponentsInChildren<RawImage>()[0].texture = Resources.Load<Texture>(skin.PrefabPath);


            //var nameText = item.transform.Find("name").GetComponent<TextMeshProUGUI>();
            //var priceText = item.transform.Find("gia").GetComponent<TextMeshProUGUI>();
            //var percentText = item.transform.Find("sale").GetComponent<TextMeshProUGUI>();
            //var iconImage = item.transform.Find("Image").GetComponent<Image>();

            //nameText.text = name;
            //priceText.text = price.ToString();
            //percentText.text = percent.ToString();
            //iconImage.sprite = Resources.Load<Sprite>(skin.image);


        }
    }
    //void OnDataLoaded(Skin skin)
    //{

    //    var newSkin = Instantiate(skinPrefab);

    //    var skinData = newSkin.GetComponent<SkinData>();

    //    skinData.nameText.text = skin.name;
    //    skinData.priceText.text = skin.price.ToString();
    //    skinData.iconImage.sprite = LoadSprite(skin.iconUrl);

 }

