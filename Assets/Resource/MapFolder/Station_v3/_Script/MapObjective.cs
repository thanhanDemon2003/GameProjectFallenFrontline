using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapObjective : MonoBehaviour
{
    public int GasCan;

    public float totalTime = 200;
    public float time;
    [Range(0, 2)]
    public float speed;


    public Slider batterySlider;
    public float batteryValue;
    public bool fuelFull;
    public bool batteryFull;
    public GameObject carLight;

    public TextMeshProUGUI indicatorText;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI gasText;

    void Start()
    {
        batteryValue = 0;
        batterySlider.maxValue = totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        ChargingTime();
    }

    public bool AddGas()
    {
        if (GasCan == 3)
        {
            StartCoroutine(Indicator("Can't Carry Anymore!"));
            return false;
        }
        GasCan++;
        return true;
    }

    public void UseGas()
    {
        if (fuelFull) return;
        if (GasCan <= 0)
        {
            StartCoroutine(Indicator("Need Gas Can!"));
            return;
        }

        GasCan--;
        batteryValue += Random.RandomRange(20, 30);
    }

    private void ChargingTime()
    {
        if (batteryValue > 100)
        {
            fuelFull = true;
            objectiveText.text = "Survive Until Finished Charging";
            batteryValue = 100;
        }

        if (fuelFull)
        {
            batteryValue -= speed * Time.deltaTime;
        }

        if (batteryValue < 0)
        {
            batteryFull = true;
            carLight.SetActive(true);
            objectiveText.text = "Get In The Car";
        }

        batterySlider.value = batteryValue;
        gasText.text = GasCan.ToString();
    }
    private IEnumerator Indicator(string text)
    {
        indicatorText.text = text;
        yield return new WaitForSeconds(4f);
        indicatorText.text = "";
    }

    public void FinisheGame()
    {
        if (!batteryFull)
        {
            StartCoroutine(Indicator("Battery is not fully charged!"));
            return;
        }
        Debug.Log(">>>>>>>Show Win Screen");
    }
}
