using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScreen : MonoBehaviour
{
    public void BackToMain()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
}
