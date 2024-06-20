using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIChangeScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SkinsOwned skins;
    public GameObject buy;
    public GameObject equip;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skinCheck()
    {
        if (skins.CheckSkins(1))
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
