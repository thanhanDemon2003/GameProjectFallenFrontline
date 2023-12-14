using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPanel : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textTip;
    void Awake()
    {
        string[] tips = { "At most, you can only carry a maximum of 3 gas tanks with you!",
            "Ammo is limited, use it wisely!",
            "You may be banned from playing for hacking",
            "The map is a bit dark, the light turns on when pressing T",
            "You can use a knife when pressing V",
            "Thank you for supporting our game! - Dot Team",
        };
        textTip.text = tips[Random.Range(0, tips.Length)];
    }

}
