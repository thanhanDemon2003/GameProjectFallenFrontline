using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Threading.Tasks;
using GunSkinModel;
using PlayerModel;
using System.IO;
public class GunSkinApi
{
    private const string BaseURL = "https://darkdisquitegame.andemongame.tech/games/getallgunskin";

    public static async Task<GunSkinData> GetAllSkins()
    {
        string url = BaseURL;


        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {

            var operation = request.SendWebRequest();

            while (!operation.isDone)
                await Task.Delay(100);


            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                return null;
            }
            string json = request.downloadHandler.text;
            GunSkinData Skins = JsonUtility.FromJson<GunSkinData>(json);
            return Skins;
        }
    }
    public static IEnumerator BuySkin(string id, string idSkin)
    {
        string url = "https://darkdisquitegame.andemongame.tech/games/buygunskin?id_Player=" + id + "&id_GunSkin=" + idSkin;
        WWWForm form = new WWWForm();
        form.AddField("id_Player", id);
        Debug.Log(url);
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            var operation = request.SendWebRequest();
            while (!operation.isDone)
                yield return null;
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                yield break;
            }
            string json = request.downloadHandler.text;
            Player Player = JsonUtility.FromJson<Player>(json);
            Data data = Player.data;
            Debug.Log("data: " + data);
            string PathFile = Application.persistentDataPath + "/Player.json";
            File.WriteAllText(PathFile, JsonUtility.ToJson(data));
            Debug.Log("Lưu dữ liệu vào file json" + data);
            GameObject.FindWithTag("textCoin").
                GetComponent<TMPro.TextMeshProUGUI>().text = data.balance.ToString();
        }
    }
}
