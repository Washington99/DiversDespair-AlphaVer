using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToShop : MonoBehaviour
{
    public void BackToShopScreen()
    {
        SceneManager.LoadSceneAsync("ShopScene");
    }

}