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
        }
        OnFocusChanged(true);

    }

    void OnEnable()
    {
        Application.focusChanged += OnFocusChanged;
    }

    void OnDisable()
    { 
        Application.focusChanged -= OnFocusChanged;
    }
    void OnFocusChanged(bool focused)
    {
            if (Application.isFocused)
            {
                Data data = JsonUtility.FromJson<Data>(File.ReadAllText(filePathPlayer));
                if (data._id == null || data._id == "") 
            {
                File.WriteAllText(filePathPlayer, "");
                startDataPlayer();
                return;
            }
                if (string.IsNullOrEmpty(File.ReadAllText(filePathPlayer)))
                {
                    File.WriteAllText(filePathPlayer, "");
                    startDataPlayer();
                    return;
                }
            string id = data._id;
            panelLoading.SetActive(true);
                StartCoroutine(CheckPlayer(id));
            
        }

       
    }

    IEnumerator CheckPlayer(string id)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://darkdisquitegame.andemongame.tech/games/checkplayer/" + id);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error. Check internet connection1!");
            Debug.LogError("Lỗi kết nối: " + www.error);
            checkInternet();
        }
        else
        {
           Player player = JsonUtility.FromJson<Player>(www.downloadHandler.text);
            Data data = player.data;
            string json1 = JsonUtility.ToJson(data);
            Data dataPlayer = JsonUtility.FromJson<Data>(json1);
            if(dataPlayer != null)
            {
                Debug.Log(dataPlayer+"hiiii");
                panelCheckInternet.SetActive(false);
                panelLoading.SetActive(false);
                string json = JsonUtility.ToJson(dataPlayer);
                File.WriteAllText(filePathPlayer, json);

                startDataPlayer();
            }
            Debug.Log("Internet connection is available");
        }
    }
    private void startDataPlayer()
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(filePathPlayer));
        if (string.IsNullOrEmpty(File.ReadAllText(filePathPlayer)))
        {
            iconLock[0].gameObject.SetActive(true);
            iconLock[1].gameObject.SetActive(true);
            iconLock[2].gameObject.SetActive(true);
            btnInvetort.interactable = false;
            btnOther.interactable = false;
            btnOther.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            btnInvetort.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            btnStore.interactable = false;
            textCoin.text = "------";
            btnStore.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            paymentBtn.SetActive(false);
            btnLogin.GetComponentInChildren<TextMeshProUGUI>().text = "Login";
            Debug.Log("click login");
            btnLogin.onClick.AddListener(() => LoginGameObject.SetActive(true));
        }
        else if(data!= null && name != null) {
            if(data.status == 1)
            {
                   checkStatusPlayer();
                return;
            }
            iconLock[0].gameObject.SetActive(false);
            iconLock[1].gameObject.SetActive(false);
            iconLock[2].gameObject.SetActive(false);
            btnOther.interactable = true;
            btnOther.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            btnInvetort.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            btnStore.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
            btnInvetort.interactable = true;
            btnStore.interactable = true;
            paymentBtn.SetActive(true);
            namePlayer.text = data.name;
            textCoin.text = data.balance.ToString();
            btnLogin.GetComponentInChildren<TextMeshProUGUI>().text = "Logout";
            btnLogin.onClick.AddListener(() => clickLogoutButton());
        } 
    } 
    public void clickLogoutButton()
    {
        Debug.Log("click logout");
        btnLogin.GetComponentInChildren<TextMeshProUGUI>().text = "Login";
        btnLogin.onClick.AddListener(() => LoginGameObject.SetActive(true));
        namePlayer.text = "";
        File.WriteAllText(filePathPlayer, "");
        PlayerPrefs.DeleteAll();
        startDataPlayer();
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
    public void checkInternet()
    {
        panelLoading.SetActive(false);
        panelCheckInternet.SetActive(true);
        panelCheckInternet.GetComponentInChildren<TextMeshProUGUI>().text = "Your network is not available, you will be locked out of online functions, please reconnect to the network to use online functions!";
            iconLock[0].gameObject.SetActive(true);
            iconLock[2].gameObject.SetActive(true);
            btnOther.interactable = false;
            btnOther.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            btnStore.interactable = false;
        paymentBtn.SetActive(false);
        btnStore.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            Debug.Log("Error. Check internet connection!");
            
    }
    public void onClickPayment()
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(filePathPlayer));
        string idgg = data.fb_id;
        string ds = data.id_discord;
        if(idgg != null)
        {
            Application.OpenURL("https://dotstudio.demondev.games/payment/#idgg=" + idgg);
            return;
        }
        else if(ds != null)
        {
            Application.OpenURL("https://dotstudio.demondev.games/payment/#ds=" + ds);
            return;
        }
        else
        {
            Application.OpenURL("https://dotstudio.demondev.games/loginpayment");
        }
    }
    public void checkStatusPlayer()
    {
        panelCheckInternet.SetActive(true);
        panelCheckInternet.GetComponentInChildren<TextMeshProUGUI>().text = "Your account has been locked. Please contact admin via email iamdemon.dev@gmail.com for more details!";
        clickLogoutButton();
    }
}
