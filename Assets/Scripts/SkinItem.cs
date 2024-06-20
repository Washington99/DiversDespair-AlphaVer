using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SkinItem : MonoBehaviour
{
    public Sprite skin;
    
    public int stars;       // 4- or 5-star skin
    public int cost = 0;
    public string status;   // On Sale or Sold or Filler
    public int index;

    void Start()
    {
        Image myImage = gameObject.GetComponent<Image>();
        myImage.sprite = skin;

        TextMeshProUGUI costText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        costText.text = "";

        if (cost > 0)
        {
            if (cost < 100)
            {
                costText.text = "0";
            }
            
            if (cost < 10)
            {
                costText.text += "0";
            }

            costText.text += cost.ToString();
        }
    }

    public void GoToSkinView()
    {
        // SceneManager.LoadSceneAsync("SkinView");
        
        if(index == -1)
            Debug.Log("A filler was pressed");
        else
            Debug.Log("Skin Item " + index + " got pressed");
    }
}
