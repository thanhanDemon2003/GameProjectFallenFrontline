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

public class LoginSrcipts : MonoBehaviour
{
    public string urlApi1 = "https://payment.dotstudio.demondev.games/api";
    // public string urlApi2 = "http://localhost:3000/games";
    public RectTransform login;
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

        UnityWebRequest www = UnityWebRequest.Get(urlApi1 + "/LoginGameWeb");
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
            textLoading.text = "Đang đăng nhập...";
            Debug.Log("Đăng nhập thành công! Dữ liệu nhận được: " + responseData);
        }
    }
    public void loadPlayer(string stt)
    {
        StartCoroutine(LoadPlayerGame(stt));
    }
    IEnumerator LoadPlayerGame(string stt)
    {
        UnityWebRequest www = UnityWebRequest.Get(urlApi1 + "/getdatauser?stt=" + stt);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
            textLoading.text = "Lỗi đăng nhập, vui lòng thử lại!";
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
            textLoading.text = "Đang lấy dữ liệu, xin vui lòng đợi!";
            Debug.Log("Dữ liệu nhận được: " + responseData);
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
        WWWForm form = new WWWForm();
        form.AddField("token", token);
        form.AddField("name", name);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/games/Login", form);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
            textLoading.text = "Lỗi đăng nhập, vui lòng thử lại!";
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
            textLoading.text = "Đăng nhập thành công";
            Debug.Log("Đăng nhập thành công! Dữ liệu nhận được: " + responseData);
        }
    }
    public void apiGetLoginDC(string token, string name)
    {
        StartCoroutine(GetLoginDC(token, name));

    }
    IEnumerator GetLoginDC(string token, string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("id_discord", token);
        form.AddField("name", token);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/games/Loginwithdiscord", form);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Lỗi kết nối: " + www.error);
            textLoading.text = "Lỗi đăng nhập, vui lòng thử lại!";
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
            data = JsonUtility.FromJson<Data>(responseData);
            string _id = data._id;
            string name1 = data.name;
            string fb_id = data.fb_id;
            Debug.Log("Dữ liệu nhận được: " + _id + name1 + fb_id);
            Debug.LogWarning("Dữ liệu nhận được: " + "" + data + "aa");
            Debug.Log("Dữ liệu nhận được: " + success + notification);
            login.gameObject.SetActive(false);
            loading.gameObject.SetActive(true);
            textLoading.text = "Đăng nhập thành công";
            Debug.Log("Đăng nhập thành công! Dữ liệu nhận được: " + responseData);
            // SavePlayer(data);
        }
    }
    public void SavePlayer(string data)
    {
        Data dataplayer = JsonUtility.FromJson<Data>(data);

        string _id = dataplayer._id;
        string name = dataplayer.name;
        string fb_id = dataplayer.fb_id;
        string id_discord = dataplayer.id_discord;
        string balance = dataplayer.balance;
        Skins[] skins = dataplayer.wardrobe;



        string filePath = Application.persistentDataPath + "/player.json";

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Lưu thành công!" + filePath);
    }


}
