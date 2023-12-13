using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using PlayerModel;
using System.Diagnostics;
using TMPro;
using UnityEngine.UI;

public class ApplyWardrobe : MonoBehaviour
{

    private string PathFile;
    private string prefabsFolderPath;
    private string gunImageFolderPath;
    public GameObject itemWardrobe;
    public GameObject vitri;
    public GameObject wardrobeItemShow;

    // Start is called before the first frame update
    void Awake()
    {
        
        applyWardrobe();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void applyWardrobe()
    {   if (itemWardrobe != null)
        {
            foreach (Transform child in vitri.transform)
            {
                Destroy(child.gameObject);
            }
        }
        PathFile = Application.persistentDataPath + "/player.json";
        prefabsFolderPath = "UI/Skins/Skin";
        gunImageFolderPath = "UI/Skins/Images";
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(PathFile));
        UnityEngine.Debug.Log("data: " + data);
        Skins[] skins = data.wardrobe;
        foreach (Skins skin in skins)

        {
            string SkinId = skin.gunskinId;
            string name = skin.nameSkin;
            string color = skin.color;
            string category = skin.category;
            UnityEngine.Debug.Log("color: " + name + " " + color);
            string prefabPath = prefabsFolderPath + "/" + color;
            string image = gunImageFolderPath + "/" + color;
            itemWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name;

            var imgFill = itemWardrobe.GetComponentsInChildren<Image>()[1];
            imgFill.sprite = Resources.Load<Sprite>(image);
            SkinDataWardrobe skinData = itemWardrobe.GetComponent<SkinDataWardrobe>();
            skinData.SetSkinData(SkinId, prefabPath, category, image, name);
            OnClickWardrobe onClickWardrobe = itemWardrobe.GetComponent<OnClickWardrobe>();
            onClickWardrobe.equitWardrobe = wardrobeItemShow;
            Instantiate(itemWardrobe, vitri.transform);
        }
    }
    public void openInventory()
    {
        applyWardrobe();
    }
}
