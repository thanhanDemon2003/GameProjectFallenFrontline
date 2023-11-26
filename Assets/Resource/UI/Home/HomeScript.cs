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
    public Button btnLogin;
    public TextMeshProUGUI namePlayer;
    public Button btnInvetort;
    public Button btnStore;
    public RawImage[] iconLock;
    // Start is called before the first frame update
    void Start()
    {
        filePathPlayer = Application.persistentDataPath + "/player.json";
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
            btnStore.GetComponentInChildren<TextMeshProUGUI>().color = Color.gray;

            btnLogin.GetComponentInChildren<TextMeshProUGUI>().text = "Login";
            btnLogin.onClick.AddListener(() => clickLoginButton());
        }
        else if(data!= null && name != null) {
            namePlayer.text = data.name;
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
        Start();
    }
}
