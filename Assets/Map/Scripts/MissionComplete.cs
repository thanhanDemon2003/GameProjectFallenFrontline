using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissionComplete : MonoBehaviour
{
    [Header("Objectives to Complete")]
    public TMP_Text Mission_1;
    public TMP_Text Mission_2;
    public TMP_Text Mission_3;

    public static MissionComplete Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetObjectiveStatus(TMP_Text missionText, bool isCompleted, string completedText, string incompleteText)
    {
        missionText.text = isCompleted ? completedText : incompleteText;
        missionText.color = isCompleted ? Color.green : Color.white;
    }
    public void Mission_1_Done(bool obj1)
    {
        SetObjectiveStatus(Mission_1, obj1, "Complete Mission!", "Collect 5 Document Case!");
    }
    public void Mission_2_Done(bool obj2)
    {
        SetObjectiveStatus(Mission_2, obj2, "Complete Mission!", "Find Virus Sample!");
    }
    public void Mission_3_Done(bool obj3)
    {
        SetObjectiveStatus(Mission_3, obj3, "Complete Mission!", "Exit the lab!");
    }
}
