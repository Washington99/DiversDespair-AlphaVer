using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class depthTracker : MonoBehaviour
{
    //new
    // public GameObject depthTrackerUI;
    [SerializeField] TextMeshProUGUI counter;
    public int points;
    float elapsedTime;
    private int scoreMultiplier;
    private float multiplierActiveTime;

    void Start()
    {
        scoreMultiplier = 1;
        multiplierActiveTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime * scoreMultiplier;
        points = Mathf.FloorToInt(elapsedTime);
        counter.text =  "Depth:\n" + points * 10 + " m";

        if (multiplierActiveTime > 0.0f)
            multiplierActiveTime -= Time.deltaTime;

        if (multiplierActiveTime <= 0.0f)
            scoreMultiplier = 1;
    }

    public void SetScoreMultiplier(int multiplier)
    {
        scoreMultiplier = multiplier;
        multiplierActiveTime = 15.0f;
    }

//new
    // public void getDepth(){
    //     return counter.text;
    // }

    // public void stopDepthTracking(){
    //     elapsedTime = 0;
    // }
}
