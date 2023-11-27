using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGunSkin : MonoBehaviour
{
    [SerializeField] GameObject smgGun;
    [SerializeField] GameObject pistolGun;


    [SerializeField] GameObject smgSkin;
    [SerializeField] GameObject pistolSkin;
    private void Awake()
    {
        GameObject smg = Instantiate(smgSkin, smgGun.transform, false);
        smg.name = "smg45";

        Instantiate(pistolSkin, pistolGun.transform, false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
