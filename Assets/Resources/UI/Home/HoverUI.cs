using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverUI : MonoBehaviour
{
    public GameObject hiddenUI;

    private void OnMouseOver()
    {
        hiddenUI.SetActive(true);
    }

    private void OnMouseExit()
    {
        hiddenUI.SetActive(false);
    }
}
