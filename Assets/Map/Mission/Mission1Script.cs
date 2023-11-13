﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mission1Script : MonoBehaviour
{
    public int numberOfDocumentsToCollect = 5;
    private int collectedDocuments = 0;
    private bool isGameOver = false;

    public void CollectDocument()
    {
        if (!isGameOver)
        {
            collectedDocuments++;

            if (collectedDocuments >= numberOfDocumentsToCollect)
            {
                Debug.Log("Collected enough documents!");
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

    public void TryExit()
    {
        if (!isGameOver)
        {
            if (collectedDocuments >= numberOfDocumentsToCollect)
            {
                Debug.Log("Mission Complete! Change to exit point...");
            }
            else
            {
                Debug.Log("You must collect enough documents!");
            }
        }
    }

    private void EndGame(bool isSuccessful)
    {
        isGameOver = true;

        if (isSuccessful)
        {
            Debug.Log("Mission Complete!");
        }
        else
        {
            Debug.Log("Mission Failed!");
        }
    }
}

