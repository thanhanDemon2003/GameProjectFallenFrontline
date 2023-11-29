using PlayerModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using TMPro;

public class OnClickWardrobe : MonoBehaviour
{
    public GameObject equitWardrobe;
    public Button mySkinWardrobe;
    public void onClickShowEquit()
    {
        equitWardrobe.SetActive(true);
        var dataWardrobe =    mySkinWardrobe.GetComponent<SkinDataWardrobe>();
        var name = dataWardrobe.nameSkin;
        var category = dataWardrobe.category;
        var pathImgSkin = dataWardrobe.pathImgSkin;
        var pathModelSkin = dataWardrobe.pathModelSkin;
        var image = equitWardrobe.GetComponentsInChildren<Image>()[1];
        Texture2D tex = new(2, 2);
        tex.LoadImage(System.IO.File.ReadAllBytes(pathImgSkin));
        image.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
        equitWardrobe.GetComponentInChildren<Button>().onClick.AddListener(() => equitWardrobe.SetActive(false));
        equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[1].text = name + " - " + category;
    }
    public void onCkickequitSkin()
    {

    }
}
