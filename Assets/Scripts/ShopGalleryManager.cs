using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGalleryManager : MonoBehaviour
{
    [SerializeField] List<Sprite> Skins;
    [SerializeField] List<int> Tiers;
    [SerializeField] List<string> Statuses;

    [SerializeField] Sprite fillerSprite;

    private List<SkinItem> SkinItems;
    private List<GameObject> GeneratedBackgrounds;

    void Start()
    {
        SkinItems = new List<SkinItem>();
        GeneratedBackgrounds = new List<GameObject>();

        SetUpSkinItems();

        SetUpPage();
    }

    void SetUpSkinItems()
    {
        for(int i = 0; i < Skins.Count; i++)
        {
            GameObject skin = new GameObject();
            skin.name = "SkinItem";
            SkinItem item = skin.AddComponent<SkinItem>();

            item.skin = Skins[i];
            item.tier = Tiers[i];            
            item.status = Statuses[i];

            if (item.status.Equals("Sold"))
                item.cost = 0;
            else if (item.tier == 3)
                item.cost = 3;
            else if (item.tier == 2)
                item.cost = 5;
            else if (item.tier == 1)
                item.cost = 10;
            item.index = i;

            item.SetUpItem();

            SkinItems.Add(item);
        }
    }

    void SetUpPage()
    {
        GameObject Canvas = GameObject.Find("ShopCanvas");
        
        // configure placement of items
        for (int i = 0; i < Math.Min(SkinItems.Count, 12); i++)
        {
            // set up skin background
            GameObject skinBackground = new GameObject();
            skinBackground.name = "SkinBackground";
            
            skinBackground.transform.SetParent(Canvas.transform);
            RectTransform skinBGTransform = skinBackground.AddComponent<RectTransform>();
            skinBGTransform.sizeDelta = new Vector2(56.25f, 70.3125f);
            skinBGTransform.SetLocalPositionAndRotation(new Vector3((i % 4) * 70.0f - 105.0f,
                                                                    (1-(float) Math.Floor((double) i/4)) * 85.0f, 0.0f),
                                                        Quaternion.identity);
            skinBackground.AddComponent<Image>();

            GeneratedBackgrounds.Add(skinBackground);

            // set up skin item
            SkinItems[i].gameObject.transform.SetParent(Canvas.transform);
            RectTransform skinTransform = SkinItems[i].gameObject.GetComponent<RectTransform>();
            skinTransform.sizeDelta = new Vector2(56.25f, 70.3125f);
            skinTransform.SetLocalPositionAndRotation(new Vector3((i % 4) * 70.0f - 105.0f,
                                                                (1-(float) Math.Floor((double) i/4)) * 85.0f, 0.0f),
                                                    Quaternion.identity);
        }

        // make fillers if necessary
        while (SkinItems.Count % 12 != 0)
        {
            GameObject Filler = Instantiate(SkinItems[0].gameObject);
            Filler.name = "Filler";

            Filler.transform.SetParent(Canvas.transform);

            RectTransform fillerTransform = Filler.GetComponent<RectTransform>();

            fillerTransform.SetLocalPositionAndRotation(new Vector3((SkinItems.Count % 4) * 70.0f - 105.0f,
                                                                (1-(float) Math.Floor((double) SkinItems.Count/4)) * 85.0f, 0.0f),
                                                    Quaternion.identity);
            
            SkinItem skinFiller = Filler.GetComponent<SkinItem>();
            skinFiller.skin = fillerSprite;
            skinFiller.tier = 0;
            skinFiller.cost = -1;
            skinFiller.status = "Filler";
            skinFiller.index = -1;

            SkinItems.Add(skinFiller);
        }

        // for cleaner hierarchy
        GameObject ShopItems = new GameObject();
        ShopItems.name = "ShopItems";
        ShopItems.transform.SetParent(Canvas.transform);

        for (int i = 0; i < GeneratedBackgrounds.Count; i++)
        {
            GeneratedBackgrounds[i].transform.SetParent(ShopItems.transform);
            SkinItems[i].gameObject.transform.SetParent(ShopItems.transform);
        }

        for (int j = GeneratedBackgrounds.Count; j < SkinItems.Count; j++)
            SkinItems[j].gameObject.transform.SetParent(ShopItems.transform);
    }
}
