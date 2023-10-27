using UnityEngine;

[CreateAssetMenu(menuName = "WeaponSkin/List")]
public class GunSkinList : ScriptableObject
{
    public GunSkin[] Skins;

    public int SkinsListLength
    {
        get
        {
            return Skins.Length;
        }
    }

    public GunSkin GetSkin(int index)
    {
        return Skins[index];
    }
}

[CreateAssetMenu(menuName = "WeaponSkin/Skin")]
public class GunSkin : ScriptableObject
{
    public string SkinName;
    public GameObject Skin;
    public int Price;
    public bool Purchased;
    public bool Equipped;
}
