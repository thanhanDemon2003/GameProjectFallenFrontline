﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission1Script : MonoBehaviour
{
    public static int numberOfDocumentsToCollect = 5;
    public static int collectedDocuments = 0;
    public static int QualityVirusSample = 1;
    public static int collectedVirusSample = 0;
    public static bool isGameOver = false;

    public static WinOrLose winOrLose;

    private void Start()
    {
        winOrLose = GameObject.FindGameObjectWithTag("Player").GetComponent<WinOrLose>();
    }
    public static void CollectDocument()
    {
        if (!isGameOver)
        {
            collectedDocuments++;

            if (collectedDocuments >= numberOfDocumentsToCollect)
            {              
                MissionComplete.Instance.Mission_1_Done(true);
            }
        }
    }

    public static void CollectVirusSample()
    {
        if (!isGameOver)
        {
            collectedVirusSample++;
            if (collectedVirusSample >= QualityVirusSample)
            {       
                MissionComplete.Instance.Mission_2_Done(true);
            }
        }      
    }
    public void PlayerIsDead()
    {
        if (!isGameOver)
        {
            EndGame(false);
        }
    }

    public static void TryExit()
    {
        if (!isGameOver)
        {
            if (collectedDocuments >= numberOfDocumentsToCollect && collectedVirusSample >= QualityVirusSample)
            {
                MissionComplete.Instance.Mission_3_Done(true);
                EndGame(true);

            }
            else
            {
                Debug.Log("You must collect enough documents!");
            }
        }
    }

    private static void EndGame(bool isSuccessful)
    {
        isGameOver = true;

        if (isSuccessful)
        {
            winOrLose.EndALevel(true);
            Debug.Log("Mission Complete, End Mode!");
        }
        else
        {
            Debug.Log("Mission Failed!");
        }
    }
}

