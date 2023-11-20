using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
public class LoginSrcipts : MonoBehaviour
{
    public string urlApi1 = "http://localhost:3001/api";
    public string urlApi2 = "http://localhost:3000/api";
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
            int tstt = playerModel.stt;
            Application.OpenURL(url);
            Debug.Log("Đăng nhập thành công! Dữ liệu nhận được: " + responseData);
        }
    }
    
}
