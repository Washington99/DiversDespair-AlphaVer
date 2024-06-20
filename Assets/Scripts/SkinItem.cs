using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinItem : MonoBehaviour
{
    public Sprite skin;
    
    public int stars;       // 4- or 5-star skin
    public int cost;
    public string status;   // On Sale or Sold or Filler

    void Start()
    {
        SpriteRenderer mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        mySpriteRenderer.sprite = skin;

        status = "On Sale";
    }

    public void GoToNewView(SkinItem item)
    {
        // SceneManager.LoadScene(whatever the scene name is);
    }
}
