using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GunSkinModel;
// using GunSkinList;

public class ApplySkin : MonoBehaviour
{
    public string prefabsFolderPath = "Assets/Resource/WeaponSkins/Skins/Skin/";


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

            var name = skin.name;
            var color = skin.color;
            skin.PrefabPath = prefabsFolderPath + color;
            Debug.Log("Skin: " + skin.PrefabPath);
            
            //   GameObject gun = Instantiate(gunPrefab);

            //   Renderer renderer = gun.GetComponentInChildren<Renderer>();
            //   renderer.material.color = skin.color;

            //   ResourceManager.SaveGunPrefab(gun, skin.id);

        }
    }
}
