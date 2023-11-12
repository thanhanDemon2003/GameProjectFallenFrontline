using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MapObjective : MonoBehaviour
{
    public int GasCan;

    public float totalTime = 100;
    public float time;
    [Range(0, 1)]
    public float speed;


    public Slider batterySlider;
    private float batteryValue;

    public TextMeshProUGUI indicatorText;
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
        if (GasCan <= 0)
        {
            StartCoroutine(Indicator("Need Gas Can!"));
            return;
        }

        GasCan--;
        time += Random.RandomRange(20, 30);
        totalTime -= time;
    }

    private void ChargingTime()
    {
        if (totalTime < 0)
        {
            totalTime = 0;
        }

        if (time > 0)
        {
            time -= Time.deltaTime;
            batteryValue += speed * Time.deltaTime;
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
}
