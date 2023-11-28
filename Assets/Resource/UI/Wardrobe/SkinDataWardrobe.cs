using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDataWardrobe : MonoBehaviour
{
    public string skinId;
    public string pathModelSkin;
    public string category;
    public string pathImgSkin;
    public string nameSkin;

    public void SetSkinData(string skinId, string prefabPath, string category, string pathImgSkin, string name)
    {
        this.skinId = skinId;
        pathModelSkin = prefabPath;
        this.category = category;
        this.pathImgSkin = pathImgSkin;
        nameSkin = name;
    }
    public void GetSkinData(string skinId, string pathModelSkin, string category, string pathImgSkin, string name)
    {
        this.skinId = skinId;
        this.pathModelSkin = pathModelSkin;
        this.category = category;
        this.pathImgSkin = pathImgSkin;
        nameSkin = name;
    }

}