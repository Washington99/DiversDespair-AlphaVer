using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopGalleryManager : MonoBehaviour
{
    [SerializeField] List<SkinItem> Skins;
    [SerializeField] Sprite fillerSprite;

    private int pageNumber;
    private int totalPages;

    void Start()
    {
        pageNumber = 1;
        totalPages = Convert.ToInt32(Math.Ceiling((double)Skins.Count / 12));

        SetUpPage();
    }

    void SetUpPage()
    {
        List<SkinItem> PageSkins = GetSkinItems();

        // configure placement of items
        for (int i = 0; i < Math.Min(Skins.Count, 12); i++)
        {
            RectTransform skinTransform = PageSkins[i].gameObject.GetComponent<RectTransform>();
            skinTransform.sizeDelta = new Vector2(56.25f, 70.3125f);
            skinTransform.SetLocalPositionAndRotation(new Vector3((i % 4) * 70.0f - 105.0f,
                                                                (1-(float) Math.Floor((double) i/4)) * 80.0f, 0.0f),
                                                    Quaternion.identity);
        }

        // make fillers if necessary
        while (PageSkins.Count % 12 != 0)
        {
            GameObject Filler = Instantiate(PageSkins[0].gameObject);
            Filler.name = "Filler";

            GameObject Canvas = GameObject.Find("Canvas");
            Filler.transform.SetParent(Canvas.transform);

            RectTransform fillerTransform = Filler.GetComponent<RectTransform>();

            fillerTransform.SetLocalPositionAndRotation(new Vector3((PageSkins.Count % 4) * 70.0f - 105.0f,
                                                                (1-(float) Math.Floor((double) PageSkins.Count/4)) * 85.0f, 0.0f),
                                                    Quaternion.identity);
            
            SkinItem skinFiller = Filler.GetComponent<SkinItem>();
            skinFiller.skin = fillerSprite;
            skinFiller.stars = 0;
            skinFiller.cost = 0;
            skinFiller.status = "Filler";
            skinFiller.index = -1;

            PageSkins.Add(skinFiller);
        }
    }
    
    List<SkinItem> GetSkinItems()
    {
        int startIndex = (pageNumber-1) * 12;

        return Skins.GetRange(startIndex, Math.Min(Skins.Count,12));
    }

    public void GoToPreviousPage()
    {
        pageNumber--;
        SetUpPage();
    }

    public void GoToNextPage()
    {
        pageNumber++;
        SetUpPage();
    }
}
