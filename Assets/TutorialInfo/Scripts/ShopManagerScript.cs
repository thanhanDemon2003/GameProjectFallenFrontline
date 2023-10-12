using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsTxt;
    // Start is called before the first frame update
    void Start()
    {
        CoinsTxt.text = "Coins:" + coins.ToString();
        shopItems [1, 1] = 1;
        shopItems [1, 2] = 2;


        shopItems [2, 1] = 10;
        shopItems [2, 2] = 20;

        shopItems [3, 1] = 0;
        shopItems [3, 2] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectdGameObject;

        if(coins >= shopItems[2, ButtonRef.GetComponent<ButtonScript>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonScript>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonScript>().ItemID]++;
            CoinsTxt.text = "Coins:" + coins.ToString();

            ButtonRef.GetComponent<ButtonScript>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonScript>().ItemID].ToString();
        }
    }
}
