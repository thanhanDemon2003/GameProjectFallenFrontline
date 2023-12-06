using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Networking;

public class ApiReward : MonoBehaviour
{
    public static ApiReward rewardApi;
    public static TMPro.TextMeshProUGUI msg;
    void Start()
    {
    }
    public void testAPi(string id, string TimeCount, int dotcoin)
    { 
        StartCoroutine(UpRewardMode1(id, TimeCount, dotcoin));
        StartCoroutine(UpRewardMode2(id, TimeCount, dotcoin));
    }


    IEnumerator UpRewardMode1 (string id, string TimeCount, int dotcoin)
    {
       WWWForm form = new WWWForm();
        form.AddField("id_Player", id);
        form.AddField("playingTime", TimeCount);
        form.AddField("gameMode", 1);
        form.AddField("dotcoin", dotcoin);
        Debug.Log("id: " + id + " TimeCount: " + TimeCount + " dotcoin: " + dotcoin);
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
    IEnumerator UpRewardMode2 (string id, string TimeCount, int dotcoin)
    {
       WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("playingTime", TimeCount);
        form.AddField("gameMode", 2);
        form.AddField("dotcoin", dotcoin);
        UnityWebRequest request = UnityWebRequest.Post("https://darkdisquitegame.andemongame.tech/games/upreward", form);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            msg.text = "Unable to connect";
            Debug.Log(request.error);
        }
        else
        {
            msg.text = "You have received " + dotcoin + " dotcoin";
            Debug.Log("Form upload complete!");
        }

    }
}
