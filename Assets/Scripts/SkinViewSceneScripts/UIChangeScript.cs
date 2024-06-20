using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SkinsOwned skins;
    public GameObject buy;
    public GameObject equip;
    public SkinManager skinManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skinCheck();
    }

    public void skinCheck()
    {
        if (skins.CheckSkins(skinManager.currentSkinIndex))
        {
            buy.SetActive(false); 
            equip.SetActive(true);
        }
        else
        {
            buy.SetActive(true);
            equip.SetActive(false);
        }
    }
}
