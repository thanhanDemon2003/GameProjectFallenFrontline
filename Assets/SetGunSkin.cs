using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGunSkin : MonoBehaviour
{
    [SerializeField] GameObject smgGun;
    [SerializeField] GameObject pistolGun;


    [SerializeField] GameObject smgSkin;
    [SerializeField] GameObject pistolSkin;
    public GameObject DefautSmg;
    public GameObject DefautPistol;
    private void Start()
    {
        SetGunSkinEquit();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetGunSkinEquit()
    {
        smgSkin = Resources.Load<GameObject>(PlayerPrefs.GetString("Primary"));
        pistolSkin = Resources.Load<GameObject>(PlayerPrefs.GetString("Secondary"));
        Debug.Log(smgSkin);


        if (smgSkin == null) {
            smgSkin = DefautSmg;
        }
        if (pistolSkin == null)
        {
            pistolSkin = DefautPistol;
        }

        GameObject smgEquit = Instantiate(smgSkin, smgGun.transform, false);
        smgEquit.name = "smg45";
        Instantiate(pistolSkin, pistolGun.transform, false);
        Debug.Log(smgSkin+ "Sung dai");
        Debug.Log(pistolSkin + "sung ngan");

    }
}
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using static OnClickWardrobe;

//public class SetGunSkin : MonoBehaviour
//{
//    [SerializeField] GameObject smgGun;
//    [SerializeField] GameObject pistolGun;


//    [SerializeField] GameObject smgSkin;
//    [SerializeField] GameObject pistolSkin;
//    public GameObject DefautSmg;
//    public GameObject DefautPistol;
//    private void Awake()
//    {
//        SetGunSkinEquit();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//    public void SetGunSkinEquit()
//    {

//        smgSkin = skinSmgEquit;
//        GameObject smgEquit = Instantiate(smgSkin, smgGun.transform, false);
//        smgEquit.name = "smg45";
//        pistolSkin = skinPistolEquit;
//        GameObject pistolEquit = Instantiate(pistolSkin, pistolGun.transform, false);
//        if (smgSkin == null)
//        {
//            GameObject smg = Instantiate(DefautSmg, smgGun.transform, false);
//            smg.name = "smg45";
//        }
//        if (pistolSkin == null)
//        {
//            Instantiate(DefautPistol, DefautPistol.transform, false);
//        }


//    }
//}

