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
    // Start is called before the first frame update
    void Start()
    {
        filePathPlayer = Application.persistentDataPath + "/player.json";
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
            btnInvetort.interactable = false;
            btnInvetort.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            btnStore.interactable = false;
            textCoin.text = "---";
            btnStore.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;
            paymentBtn.SetActive(false);
            btnLogin.GetComponentInChildren<TextMeshProUGUI>().text = "Login";
            btnLogin.onClick.AddListener(() => clickLoginButton());
        }
        else if(data!= null && name != null) {
            paymentBtn.SetActive(true);
            namePlayer.text = data.name;
            textCoin.text = data.balance.ToString();
            btnLogin.GetComponentInChildren<TextMeshProUGUI>().text = "Logout";
            btnLogin.onClick.AddListener(() => clickLogoutButton());
        }
       
    }
    public void clickLoginButton()
    {
        Debug.Log("click login");
        SceneManager.LoadScene("Index");

    }
    public void clickLogoutButton()
    {
        Debug.Log("click logout");
        btnLogin.GetComponentInChildren<TextMeshProUGUI>().text = "Login";
        btnLogin.onClick.AddListener(() => clickLoginButton());
        namePlayer.text = "";
        File.WriteAllText(filePathPlayer, "");
        File.WriteAllText(filePathGun, "");
        ResetScene();
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
