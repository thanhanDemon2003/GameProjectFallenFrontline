using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using TMPro;
using RewardModel;
using static ApiReward;

public class ApplyReward : MonoBehaviour
{
    public GameObject itemReward;
    public Transform contentReward;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    public async void ApplyRewardData()
    {
        if (itemReward != null)
        {
               foreach (Transform child in contentReward)
            {
                Destroy(child.gameObject);
            }
        }
        var player = File.ReadAllText(Application.persistentDataPath + "/Player.json");
        PlayerModel.Data data = JsonUtility.FromJson<PlayerModel.Data>(player);
        var idPlayer = data._id;
        Debug.Log(data._id);

        Reward rewardData = await GetRewardModel(idPlayer);
        Debug.Log(rewardData);
        foreach (Data reward in rewardData.data)
        {
            var timeGoble = reward.Date;
            DateTime dateTime = DateTime.Parse(timeGoble);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            TimeZoneInfo vietnamZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");

            DateTime vietnamDateTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, vietnamZone);
            string timeResult = vietnamDateTime.ToString("dd/MM/yyyy HH:mm");
            itemReward.GetComponentsInChildren<TextMeshProUGUI>()[0].text = timeResult;
            itemReward.GetComponentsInChildren<TextMeshProUGUI>()[4].text = reward.playingTime;
            itemReward.GetComponentsInChildren<TextMeshProUGUI>()[6].text = reward.dotcoin.ToString();
            itemReward.GetComponentsInChildren<TextMeshProUGUI>()[2].text = reward.gameMode.ToString();
            Instantiate(itemReward, contentReward);
        }
    }
    public void openReward()
    {
        ApplyRewardData();
    }


}
