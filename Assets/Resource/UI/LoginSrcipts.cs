using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
public class LoginSrcipts : MonoBehaviour
{
    public string urlApi1 = "http://localhost:3001/api";
    public string urlApi2 = "http://localhost:3000/games";
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
            PlayerModel playerModel = JsonUtility.FromJson<PlayerModel>(responseData);
            string url = playerModel.url;
            string stt = playerModel.stt;
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
            PlayerModel playerModel = JsonUtility.FromJson<PlayerModel>(responseData);
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
        form.AddField("myField", token);
        form.AddField("token", token);
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
            PlayerModel playerModel = JsonUtility.FromJson<PlayerModel>(responseData);
            string data = playerModel.data;
            Debug.Log("Dữ liệu nhận được: " + data);
            login.gameObject.SetActive(false);
            loading.gameObject.SetActive(true);
            textLoading.text = "Đăng nhập thành công";
            Debug.Log("Đăng nhập thành công! Dữ liệu nhận được: " + responseData);
        }
    }
    public void apiGetLoginDC(string token, string name)
    {
        // StartCoroutine(GetLoginDC(stt));
        Debug.Log("Đăng nhập thành công! Dữ liệu nhận được: " + token + " " + name);
    }
}
