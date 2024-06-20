using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public int currentSkinIndex;
    public GameObject[] skinModels;

    void Start()
    {
        foreach (GameObject skin in skinModels)
            skin.SetActive(false);

        skinModels[currentSkinIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
