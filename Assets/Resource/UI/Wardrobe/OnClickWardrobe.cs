using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickWardrobe : MonoBehaviour
{
    public GameObject equitWardrobe;
    public void onClickShowEquit()
    {
        equitWardrobe.SetActive(true);
    }
}
