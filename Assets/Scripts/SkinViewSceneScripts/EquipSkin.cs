using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSkin : MonoBehaviour
{
    public SkinManager skinManager;

    // This function should be called when the equip button is pressed
    public void EquipSelectedSkin()
    {
        PlayerPrefs.SetInt("SelectedSkin", skinManager.currentSkinIndex);
        PlayerPrefs.Save();
        Debug.Log("Skin " + skinManager.currentSkinIndex + " equipped.");
    }
}
