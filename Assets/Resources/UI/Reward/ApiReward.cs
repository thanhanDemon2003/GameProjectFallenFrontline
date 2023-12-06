using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;
using PlayerModel;
public class ApiReward : MonoBehaviour
{
    public static ApiReward rewardApi;
    public static string msg;
 

    
    public static IEnumerator UpRewardMode1 (string playingTime, int dotcoin)
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.persistentDataPath + "/Player.json"));
        var id = data._id;
        WWWForm form = new WWWForm();
        form.AddField("id_Player", id);
        form.AddField("playingTime", playingTime);
        form.AddField("gameMode", 1);
        form.AddField("dotcoin", dotcoin);
        Debug.Log("id: " + id + " TimeCount: " + playingTime + " dotcoin: " + dotcoin);
        UnityWebRequest request = UnityWebRequest.Post("https://darkdisquitegame.andemongame.tech/games/upreward", form);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }

    }
    public static IEnumerator UpRewardMode2 (string playingTime, int dotcoin)
    {
        Data data = JsonUtility.FromJson<Data>(File.ReadAllText(Application.persistentDataPath + "/Player.json"));
        var id = data._id;
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("playingTime", playingTime);
        form.AddField("gameMode", 2);
        form.AddField("dotcoin", dotcoin);
        UnityWebRequest request = UnityWebRequest.Post("https://darkdisquitegame.andemongame.tech/games/upreward", form);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            msg = "Unable to connect";
            Debug.Log(request.error);
        }
        else
        {
            msg = "You have received " + dotcoin + " dotcoin";
            Debug.Log("Form upload complete!");
        }

    }
}
