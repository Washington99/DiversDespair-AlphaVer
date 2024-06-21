using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int runCoinCount;
    public TextMeshProUGUI runCoinText;
    private const string TotalCoinsKey = "TotalCoins";

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the run coin count to 0 at the start of each run
        runCoinCount = 0;
        UpdateRunCoinText();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRunCoinText();
    }

    public void AddCoins(int amount)
    {
        runCoinCount += amount;
        UpdateRunCoinText();
    }

    public void SaveRunCoins()
    {
        int totalCoins = PlayerPrefs.GetInt(TotalCoinsKey, 0);
        totalCoins += runCoinCount;
        PlayerPrefs.SetInt(TotalCoinsKey, totalCoins);
        PlayerPrefs.Save();
    }

    private void UpdateRunCoinText()
    {
        runCoinText.text = " " + runCoinCount.ToString();
    }
}
