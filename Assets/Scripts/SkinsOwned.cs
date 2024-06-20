using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinsOwned : MonoBehaviour
{
    // Start is called before the first frame update
    public bool skinOwned;
    public List <int> skinsOwned = new List<int>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckSkins(int skinIndex)
    {
        skinOwned = false;
        foreach (int skin in skinsOwned)
        {
            if (skin == skinIndex)
                skinOwned = true;
        }
        return skinOwned;
    }

    public void AddSkins(int skinIndex)
    {
        skinsOwned.Add(skinIndex);
    }
}
