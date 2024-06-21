using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuySkin : MonoBehaviour
{
    // Start is called before the first frame update
    private const string TotalCoinsKey = "TotalCoins";
    public SkinsOwned skins;
    public SkinManager skinManager;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BoughtSkin()
    {
        int totalCoins = PlayerPrefs.GetInt(TotalCoinsKey, 0);
        int cost = PlayerPrefs.GetInt("SelectedSkinCost", 0);
        totalCoins -= cost;
        PlayerPrefs.SetInt(TotalCoinsKey, totalCoins);
        PlayerPrefs.Save();

        skins.AddSkins(skinManager.currentSkinIndex);
    }
}
