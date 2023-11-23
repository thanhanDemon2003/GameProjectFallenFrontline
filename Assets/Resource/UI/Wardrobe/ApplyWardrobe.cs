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

    // Start is called before the first frame update
    void Awake()
    {
        PathFile = Application.persistentDataPath + "/Player.json";
        prefabsFolderPath = "Assets/Resource/UI/Skins/Skin";
        gunImageFolderPath = "Assets/Resource/UI/Skins/Images";
        applyWardrobe();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void applyWardrobe()
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(PathFile));
        UnityEngine.Debug.Log("data: " + data);
        Skins[] skins = data.wardrobe;
        foreach (Skins skin in skins)
        {
            string name = skin.nameSkin;
            string color = skin.color;
            UnityEngine.Debug.Log("color: " + name + " " + color);
            string prefab = prefabsFolderPath + "/" + color;
            string image = gunImageFolderPath + "/" + name + ".png";
            itemWardrobe.GetComponentsInChildren<TextMeshProUGUI>()[0].text = name;

            var imgFill = itemWardrobe.GetComponentsInChildren<Image>()[0];

            Texture2D tex = new(2, 2);
            tex.LoadImage(File.ReadAllBytes(image));
            imgFill.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
            Instantiate(itemWardrobe, vitri.transform);
        }
        
    }
}
