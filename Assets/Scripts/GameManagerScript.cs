using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;

    //new
    [SerializeField] TextMeshProUGUI currentScore;
    [SerializeField] TextMeshProUGUI finalScore;
    // Start is called before the first frame update
    void Start()
    {
        // Cursor.visible = false;
        // Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeInHierarchy){
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        // else{
        //     Cursor.visible = false;
        //     Cursor.lockState = CursorLockMode.Locked;
        // }
    }

    public void gameOver(){
        gameOverUI.SetActive(true);
        finalScore.text = currentScore.text;

        currentScore.gameObject.SetActive(false);
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu(){
        SceneManager.LoadScene("Main Menu");
    }
}
