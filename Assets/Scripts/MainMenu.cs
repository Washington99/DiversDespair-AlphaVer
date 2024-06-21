using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("GameProper");
    }

    public void ShopMenu() 
    {
        SceneManager.LoadSceneAsync("ShopScene");
    }
}
