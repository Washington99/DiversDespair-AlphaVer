using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsOwned : MonoBehaviour
{
    // Start is called before the first frame update
    public bool skinOwned;
    public int [] skinsOwnedIndex;
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
        foreach (int skin in skinsOwnedIndex)
        {
            if (skin == skinIndex)
                skinOwned = true;
        }
        return skinOwned;
    }
}
