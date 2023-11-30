using PlayerModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using TMPro;
using System.IO;

public class OnClickWardrobe : MonoBehaviour
{
    public GameObject equitWardrobe;
    public Button mySkinWardrobe;
    public static GameObject skinSmgEquit;
    public static GameObject skinPistolEquit;
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
        equitWardrobe.GetComponentInChildren<Button>().onClick.AddListener(() => onCkickequitSkin(pathModelSkin, category));
        equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[1].text = name + " - " + category;
    }
    public void onCkickequitSkin(string pathModelSkin, string category)
    {
        equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Selected";
        equitWardrobe.GetComponentInChildren<Button>().colors = ColorBlock.defaultColorBlock;
        equitWardrobe.GetComponentInChildren<Button>().interactable = false;
        if (category == "Primary")
        {
            skinSmgEquit = Resources.Load<GameObject>(pathModelSkin);
            Debug.Log(pathModelSkin+"abcd");
            Debug.Log(skinSmgEquit);
            
        }
        else if (category == "Secondary")
        {
            skinPistolEquit = Resources.Load<GameObject>(pathModelSkin);
            Debug.Log(skinPistolEquit);
            Debug.Log(pathModelSkin +"  "+"abcd");

        }
    }
}
