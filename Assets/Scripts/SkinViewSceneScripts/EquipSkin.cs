using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSkin : MonoBehaviour
{
    public SkinManager skinManager;

    // This function should be called when the equip button is pressed
    public void EquipSelectedSkin()
    {
        PlayerPrefs.SetInt("EquippedSkin", skinManager.currentSkinIndex);
        PlayerPrefs.Save();
        Debug.Log("Skin " + skinManager.currentSkinIndex + " equipped.");

        // Update the UI after equipping the skin
        FindObjectOfType<UIChangeScript>().skinCheck();
    }
}
