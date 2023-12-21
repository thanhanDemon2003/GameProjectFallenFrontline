using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;
using PlayerModel;
using System;

public class HomeScript : MonoBehaviour
{
    private string filePathPlayer;
    public Button btnLogin;
    public TextMeshProUGUI namePlayer;
    public Button btnInvetort;
    public Button btnStore;
    public TextMeshProUGUI textCoin;
    public RawImage[] iconLock;
    public GameObject paymentBtn;
    public Button btnOther;
    public GameObject LoginGameObject;
    public GameObject panelLoading;
    public GameObject panelCheckInternet;
    public GameObject panelLoad;


    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale =  1f;
        filePathPlayer = Application.persistentDataPath + "/player.json";
        if (!File.Exists(filePathPlayer))
        {
            File.WriteAllText(filePathPlayer, "");
        };

    }

    public void clickOnLoadMap(int index)
    {
        panelLoad.SetActive(true);
        StartCoroutine(LoadMap(index));
    }

    private IEnumerator LoadMap(int index)
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(index);
    }
}
