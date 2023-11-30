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
    // Start is called before the first frame update
    void Start()
    {
        filePathPlayer = Application.persistentDataPath + "/player.json";
        if (!File.Exists(filePathPlayer))
        {
            File.WriteAllText(filePathPlayer, "");
        }
        filePathGun = Application.persistentDataPath + "/wardrobe.json";
        startDataPlayer();
    }

    // Update is called once per frame
    void Update()
    {
       
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
}
