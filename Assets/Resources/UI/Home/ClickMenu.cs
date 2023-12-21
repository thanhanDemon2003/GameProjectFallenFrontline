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
    public GameObject instruct;
    public float lastClickTime;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void clickdownOff()
    {
        story.SetActive(false);
        wardrobe.SetActive(false);
        setting.SetActive(false);
        instruct.SetActive(false);
    }
}
