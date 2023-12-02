using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public class ClickMenu : MonoBehaviour
{

    public GameObject story;
    public GameObject wardrobe;
    public GameObject shop;
    public GameObject other;
    public GameObject setting;
    public float lastClickTime;
    // Start is called before the first frame update
    void Start()
    {
        lastClickTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseDown()
    {
        if (Time.time - lastClickTime < 0.3f)
        {
            Debug.Log("Double clicked");
            clickdownOff();
        }
        lastClickTime = Time.time;
    }
    public void clickdownOff()
    {
        //story.SetActive(false);
        //wardrobe.SetActive(false);
        //shop.SetActive(false);
        //other.SetActive(false);
        //setting.SetActive(false);
    }
}
