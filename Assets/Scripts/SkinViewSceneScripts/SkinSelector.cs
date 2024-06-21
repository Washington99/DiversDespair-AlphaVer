using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public int currentSkinIndex;
    public GameObject[] skins;

    void Start()
    {
        currentSkinIndex = PlayerPrefs.GetInt("EquippedSkin", 0);
        foreach (GameObject skin in skins)
            skin.SetActive(false);

        skins[currentSkinIndex].SetActive(true);
    }
}
