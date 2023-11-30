using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using PlayerModel;
using System;
using UnityEngine.Rendering.LookDev;

public class HomeScript : MonoBehaviour
{
    private string filePathPlayer;
    private string filePathGun;
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
    // Start is called before the first frame update
    void Awake()
    {
        filePathPlayer = Application.persistentDataPath + "/player.json";
        if (!File.Exists(filePathPlayer))
        {
            File.WriteAllText(filePathPlayer, "");
        }
        filePathGun = Application.persistentDataPath + "/wardrobe.json";
        chekcInternet();
        startDataPlayer();
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
            string id = data._id;
            if (id == null || id =="")
            {
                File.WriteAllText(filePathPlayer, "");
                startDataPlayer();
                return;
            }
            panelLoading.SetActive(true);
            StartCoroutine(CheckPlayer(id));
        }
    }

    IEnumerator CheckPlayer(string id)
    {
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:3000/games/checkplayer/"+ id);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
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
                panelLoading.SetActive(false);
                string json = JsonUtility.ToJson(dataPlayer);
                File.WriteAllText(filePathPlayer, json);
                startDataPlayer();
            }   
        }
    }       
    private void startDataPlayer()
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(filePathPlayer));
        if(data == null)
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
        File.WriteAllText(filePathGun, "");
        PlayerPrefs.DeleteAll();
        ResetScene();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void clickOnLoadMap1()
    {
        SceneManager.LoadScene(1);
    }
    public void clickOnLoadMap2()
    {
        SceneManager.LoadScene(2);
    }
    public void chekcInternet()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable) {
            iconLock[0].gameObject.SetActive(true);
            iconLock[2].gameObject.SetActive(true);
            btnOther.interactable = false;
            btnOther.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            btnStore.interactable = false;
            btnStore.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            Debug.Log("Error. Check internet connection!");
            return;
        }
        else
        {
            Debug.Log("Internet connection is available");
        }
    }
    public void onClickPayment()
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(filePathPlayer));
        string idgg = data.fb_id;
        string ds = data.id_discord;
        if(idgg != null)
        {
            Application.OpenURL("https://dotstudio.andemongame.tech/payment/#idgg="+ idgg);
            return;
        }
        else if(ds != null)
        {
            Application.OpenURL("https://dotstudio.andemongame.tech/payment/#ds="+ds);
            return;
        }
        else
        {
            Application.OpenURL("https://dotstudio.andemongame.tech/loginpayment");
        }
    }
}
