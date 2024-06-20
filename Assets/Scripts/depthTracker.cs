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
        points = 0;
        scoreMultiplier = 1;
        multiplierActiveTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        points = Mathf.FloorToInt(elapsedTime) * scoreMultiplier;
        counter.text =  "Depth:\n" + points + " m";

        if (multiplierActiveTime > 0.0f) {
            
            multiplierActiveTime -= Time.deltaTime;
        }
            
        if (multiplierActiveTime <= 0.0f) {
            scoreMultiplier = 1;elapsedTime = points * scoreMultiplier; // So elapsed time doesnt reset at multiplier end
        }
            
    }

    public void SetScoreMultiplier(int multiplier, int duration)
    {
        scoreMultiplier = multiplier;
        multiplierActiveTime = duration;
    }

//new
    // public void getDepth(){
    //     return counter.text;
    // }

    // public void stopDepthTracking(){
    //     elapsedTime = 0;
    // }
}
