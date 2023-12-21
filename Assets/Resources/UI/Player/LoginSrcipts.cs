using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using TMPro;
using PlayerModel;
public class LoginSrcipts : MonoBehaviour
{
    public RectTransform login;
    public RectTransform cancel;

    public RectTransform loading;
    public TextMeshProUGUI textLoading;
    


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clickLoginButton()
    {
        StartCoroutine(Login());
    }
    IEnumerator Login()
    {

        UnityWebRequest www = UnityWebRequest.Get("https://dotstudio.demondev.games/api/LoginGameWeb");
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
        }
        else
        {
            string responseData = www.downloadHandler.text;
            Player player = JsonUtility.FromJson<Player>(responseData);
            string url = player.url;
            string stt = player.stt;
            Application.OpenURL(url);
            loadPlayer(stt);
            login.gameObject.SetActive(false);
            loading.gameObject.SetActive(true);
            cancel.gameObject.SetActive(true);
            textLoading.text = "Login...";
        }
    }
    public void loadPlayer(string stt)
    {
        StartCoroutine(LoadPlayerGame(stt));
    }
    public void cancelLoadPlayer()
    {
        login.gameObject.SetActive(true);
        loading.gameObject.SetActive(false);
        cancel.gameObject.SetActive(false);
        textLoading.text = "Login stopped!";
        StopCoroutine(LoadPlayerGame(""));
    }
    IEnumerator LoadPlayerGame(string stt)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://dotstudio.demondev.games/api/getdatauser?stt=" + stt);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
            textLoading.text = "Error, please try again!";
            login.gameObject.SetActive(true);
            loading.gameObject.SetActive(false);

        }
        else
        {
            string responseData = www.downloadHandler.text;
            Player playerModel = JsonUtility.FromJson<Player>(responseData);
            string token = playerModel.token;
            string method = playerModel.method;
            string name = playerModel.name;
            textLoading.text = "Retrieving data, please wait!";
            if (method == "google")
            {
                apiGetLoginGG(token, name);
            }
            else if (method == "discord")
            {
                apiGetLoginDC(token, name);
            }
        }

    }
    public void apiGetLoginGG(string token, string name)
    {
        StartCoroutine(GetLoginGG(token, name));
    }
    IEnumerator GetLoginGG(string token, string name)
    {
        cancel.gameObject.SetActive(false);
        WWWForm form = new WWWForm();
        form.AddField("token", token);
        form.AddField("name", name);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/games/Login", form);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
            Player playerModel = JsonUtility.FromJson<Player>(www.downloadHandler.text);
            textLoading.text = playerModel.notification;
            login.gameObject.SetActive(true);
            loading.gameObject.SetActive(false);

        }
        else
        {
            string responseData = www.downloadHandler.text;
            Player playerModel = JsonUtility.FromJson<Player>(responseData);
            Data data = playerModel.data;
            Debug.Log("Dữ liệu nhận được: " + data);
            login.gameObject.SetActive(false);
            loading.gameObject.SetActive(true);
            textLoading.text = "Logged in successfully";
            SavePlayer(data);
        }
    }
    public void apiGetLoginDC(string token, string name)
    {
        StartCoroutine(GetLoginDC(token, name));

    }
    IEnumerator GetLoginDC(string token, string name)
    {
        cancel.gameObject.SetActive(false);
        WWWForm form = new WWWForm();
        form.AddField("id_discord", token);
        form.AddField("name", name);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/games/Loginwithdiscord", form);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
            Player playerModel = JsonUtility.FromJson<Player>(www.downloadHandler.text);
            textLoading.text = playerModel.notification;
            login.gameObject.SetActive(true);
            loading.gameObject.SetActive(false);

        }
        else
        {
            string responseData = www.downloadHandler.text;
            Player playerModel = JsonUtility.FromJson<Player>(responseData);
            bool success = playerModel.success;
            string notification = playerModel.notification;
            Data data = playerModel.data;
            Debug.LogWarning("Dữ liệu nhận được: " + "" + data + "aa");
            Debug.Log("Dữ liệu nhận được: " + success + notification);
            login.gameObject.SetActive(false);
            loading.gameObject.SetActive(true);
            textLoading.text = "";
            Debug.Log("Đăng nhập thành công! Dữ liệu nhận được: " + responseData);
            SavePlayer(data);
        }
    }

    private void SavePlayer(Data data)
    {

        Debug.Log("Lưu dữ liệu vào file json" + data);
        string _id = data._id;
        string name = data.name;
        string fb_id = data.fb_id;
        string id_discord = data.id_discord;
        int balance = data.balance;
        Skins[] skins = data.wardrobe;

        Debug.Log("Dotcoin nè: "+ balance );
        string filePath = Application.persistentDataPath + "/player.json";
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        
        Debug.Log("Lưu thành công!" + filePath);
        Debug.Log("Dữ liệu nhận được: " + _id + name + fb_id + id_discord + balance + skins);
        SceneManager.LoadSceneAsync(1);
    }


}
