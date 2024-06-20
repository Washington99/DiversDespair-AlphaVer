using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsOwned : MonoBehaviour
{
    public List<int> skinsOwned = new List<int>();

    private const string SkinsOwnedKey = "SkinsOwned";

    void Start()
    {
        LoadSkins();
    }

    public bool CheckSkins(int skinIndex)
    {
        return skinsOwned.Contains(skinIndex);
    }

    public void AddSkins(int skinIndex)
    {
        if (!skinsOwned.Contains(skinIndex))
        {
            skinsOwned.Add(skinIndex);
            SaveSkins();
        }
    }

    private void SaveSkins()
    {
        // Convert the list to a comma-separated string
        string skinsString = string.Join(",", skinsOwned);
        PlayerPrefs.SetString(SkinsOwnedKey, skinsString);
        PlayerPrefs.Save();
    }

    private void LoadSkins()
    {
        // Load the comma-separated string from PlayerPrefs
        string skinsString = PlayerPrefs.GetString(SkinsOwnedKey, "");

        // If the string is not empty, convert it back to a list
        if (!string.IsNullOrEmpty(skinsString))
        {
            string[] skinsArray = skinsString.Split(',');
            skinsOwned = new List<int>();
            foreach (string skin in skinsArray)
            {
                if (int.TryParse(skin, out int skinIndex))
                {
                    skinsOwned.Add(skinIndex);
                }
            }
        }
    }
}
