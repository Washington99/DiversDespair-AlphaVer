using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SkinItem : MonoBehaviour
{
    public Sprite skin;
    
    public int tier;        // Tier 1, 2 or 3
    public int cost = 0;
    public string status;   // On Sale, Sold or Filler
    public int index = 0;

    private Button myButton;
    private Image myImage;
    private TextMeshProUGUI costText;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name.Equals("ShopScene"))
        {
            if (index == -1)
            {
                myButton = gameObject.GetComponent<Button>();
                myButton.onClick.AddListener(() => GoToSkinView());
    
                myImage = gameObject.GetComponent<Image>();
                myImage.sprite = skin;
    
                costText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            }

            if (cost > 0)
                costText.text = cost.ToString();
            else if (cost == 0)
                costText.text = "SOLD";
            else
            {
                costText.text = "";
                myButton.interactable = false;
            }
        }
    }

    public void SetUpItem()
    {
        // set up rect transform
        RectTransform rt = gameObject.AddComponent<RectTransform>();

        // set up button
        myButton = gameObject.AddComponent<Button>();
        myButton.onClick.AddListener(() => GoToSkinView());

        // set up image
        myImage = gameObject.AddComponent<Image>();
        myImage.sprite = skin;

        // set up background of the cost UI
        GameObject costUIBackground = new GameObject();
        costUIBackground.name = "CostBG";
        costUIBackground.transform.SetParent(gameObject.transform);

        RectTransform bgRectTransform = costUIBackground.AddComponent<RectTransform>();
        bgRectTransform.sizeDelta = new Vector2(56.25f, 20.0f);
        bgRectTransform.SetLocalPositionAndRotation(new Vector3(0.0f, -26.0f, 0.0f), Quaternion.identity);

        Image bgColor = costUIBackground.AddComponent<Image>();
        bgColor.color = new Color(0.5f, 0.5f, 0.5f, 0.95f);
        
        // set up the cost UI
        GameObject costTextObj = new GameObject();
        costTextObj.name = "CostText";
        costTextObj.transform.SetParent(gameObject.transform);

        RectTransform txtRectTransform = costTextObj.AddComponent<RectTransform>();
        txtRectTransform.SetLocalPositionAndRotation(new Vector3(0.0f, -26.0f, 0.0f), Quaternion.identity);

        costText = costTextObj.AddComponent<TextMeshProUGUI>();
        costText.fontStyle = FontStyles.Bold;
        costText.fontSize = 16;
        costText.color = Color.black;
        costText.alignment = TextAlignmentOptions.Center;
        costText.text = cost.ToString();
    }

    void GoToSkinView()
    {
        // SceneManager.LoadSceneAsync("SkinView");
        Debug.Log("Skin Item " + index + " got pressed");
    }
}
