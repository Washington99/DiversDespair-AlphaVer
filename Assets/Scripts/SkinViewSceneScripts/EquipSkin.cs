using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSkin : MonoBehaviour
{
    public int skinIndex;

    // This function should be called when the equip button is pressed
    public void EquipSelectedSkin()
    {
        PlayerPrefs.SetInt("SelectedSkin", skinIndex);
        PlayerPrefs.Save();
        Debug.Log("Skin " + skinIndex + " equipped.");
    }
}
