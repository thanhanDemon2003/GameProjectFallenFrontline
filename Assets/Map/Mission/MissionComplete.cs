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

    public static MissionComplete occurrence;

    private void Awake()
    {
        occurrence = this;
    }

    public void GetObjectiveDone(bool obj1, bool obj2, bool obj3)
    {
        if(obj1 == true)
        {
            Mission_1.text = "Collected full Document!";
            Mission_1.color = Color.green;
        }
        else
        {
            Mission_1.text = "Find and collect 5 Document!";
            Mission_1.color = Color.green;
        }
        if (obj2 == true)
        {
            Mission_2.text = "Collected Virus Sample!";
            Mission_2.color = Color.green;
        }
        else {
            Mission_2.text = "Find and collect Virus Sample!";
            Mission_2.color = Color.green;
        }
        if (obj3 == true)
        {
            Mission_3.text = "Get out Lab!";
            Mission_3.color = Color.green;
        }
        else
        {
            Mission_3.text = "Get out Lab!";
            Mission_3.color = Color.green;
        }
    }
}
