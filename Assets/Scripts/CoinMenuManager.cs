using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinMenuManager : MonoBehaviour
{
    public TextMeshProUGUI totalCoinsText;
    private const string TotalCoinsKey = "TotalCoins";

    void Start()
    {
        int totalCoins = PlayerPrefs.GetInt(TotalCoinsKey, 0);
        totalCoinsText.text = " " + totalCoins.ToString();
    }

    private void Update()
    {
        int totalCoins = PlayerPrefs.GetInt(TotalCoinsKey, 0);
        totalCoinsText.text = " " + totalCoins.ToString();
    }
}

