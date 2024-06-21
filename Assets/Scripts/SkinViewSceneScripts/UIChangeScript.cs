using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChangeScript : MonoBehaviour
{
    public SkinsOwned skins;
    public GameObject buy;
    public GameObject equip;
    public GameObject equipped;
    public SkinManager skinManager;

    void Start()
    {
        skinCheck();
    }

    void Update()
    {
        skinCheck();
    }

    public void skinCheck()
    {
        int equippedSkin = PlayerPrefs.GetInt("EquippedSkin", 0);

        if (skins.CheckSkins(skinManager.currentSkinIndex))
        {
            buy.SetActive(false);

            if (skinManager.currentSkinIndex == equippedSkin)
            {
                equip.SetActive(false);
                equipped.SetActive(true);
            }
            else
            {
                equip.SetActive(true);
                equipped.SetActive(false);
            }
        }
        else
        {
            buy.SetActive(true);
            equip.SetActive(false);
            equipped.SetActive(false);
        }
    }
}
