using System.Collections;
using System.Collections.Generic;
using FPS.Player;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SliderMouse : MonoBehaviour
{
    [SerializeField] Slider  slider;
    private PlayerController sliderPlayer;


     void Start()
     {
        sliderPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        sliderPlayer.mouseSensitive = 5;

        if (!PlayerPrefs.HasKey("sliderPlayer"))
        {
            PlayerPrefs.SetFloat("sliderPlayer", 5);
            Load();
        }
        else
        {
            Load();
        }

     }
      void Update()
      {

      }

      public void MouseSensitivity()
      {
         sliderPlayer.mouseSensitive = slider.value;
        Save();
      }

     private void Load()
     {
        slider.value = PlayerPrefs.GetFloat("sliderPlayer");
     }
     private void Save()
     {
        PlayerPrefs.SetFloat("sliderPlayer", slider.value);
     }
}
