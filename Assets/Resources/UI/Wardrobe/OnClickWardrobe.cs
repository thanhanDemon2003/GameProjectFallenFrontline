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

    void Awake()
    {
        if(PlayerPrefs.GetString("Secondary") == "")
        {
            PlayerPrefs.SetString("Secondary", "UI/Skins/Skin/PistolDefault");
        }
        if (PlayerPrefs.GetString("Primary") == "")
        {
            PlayerPrefs.SetString("Primary", "UI/Skins/Skin/SMGDefault");
        }
    }
    public void onClickShowEquit()
    {
        equitWardrobe.SetActive(true);
        var dataWardrobe =    mySkinWardrobe.GetComponent<SkinDataWardrobe>();
        var name = dataWardrobe.nameSkin;
        var category = dataWardrobe.category;
        var pathImgSkin = dataWardrobe.pathImgSkin;
        var pathModelSkin = dataWardrobe.pathModelSkin;
        var image = equitWardrobe.GetComponentsInChildren<Image>()[1];
        image.sprite = Resources.Load<Sprite>(pathImgSkin);
        equitWardrobe.GetComponentInChildren<Button>().onClick.AddListener(() => onCkickequitSkin(pathModelSkin, category));
        equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[1].text = name + " - " + category;
        if(category == "Primary")
        {
          string checkSkin =  PlayerPrefs.GetString("Primary");
          if (checkSkin == pathModelSkin)
            {
                equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Selected";
                equitWardrobe.GetComponentInChildren<Button>().colors = ColorBlock.defaultColorBlock;
                equitWardrobe.GetComponentInChildren<Button>().interactable = false;
            }
            else
            {
                equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Equip";
                equitWardrobe.GetComponentInChildren<Button>().colors = ColorBlock.defaultColorBlock;
                equitWardrobe.GetComponentInChildren<Button>().interactable = true;
            }
        }
        else if (category == "Secondary")
        {
            string checkSkin = PlayerPrefs.GetString("Secondary");
            if (checkSkin == pathModelSkin)
            {
                equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Selected";
                equitWardrobe.GetComponentInChildren<Button>().colors = ColorBlock.defaultColorBlock;
                equitWardrobe.GetComponentInChildren<Button>().interactable = false;
            }
            else
            {
                equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Equit";
                equitWardrobe.GetComponentInChildren<Button>().colors = ColorBlock.defaultColorBlock;
                equitWardrobe.GetComponentInChildren<Button>().interactable = true;
            }
        }
    }
    public void onCkickequitSkin(string pathModelSkin, string category)
    {


        equitWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = "Selected";
        equitWardrobe.GetComponentInChildren<Button>().colors = ColorBlock.defaultColorBlock;
        equitWardrobe.GetComponentInChildren<Button>().interactable = false;
        if (category == "Primary")
        {
            PlayerPrefs.SetString("Primary", pathModelSkin);
            Debug.Log(pathModelSkin);
            
        }
        else if (category == "Secondary")
        {
            PlayerPrefs.SetString("Secondary", pathModelSkin);
            Debug.Log(pathModelSkin);

        }
    }
}
