using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class depthTracker : MonoBehaviour
{
    //new
    // public GameObject depthTrackerUI;
    [SerializeField] TextMeshProUGUI counter;
    
    [SerializeField] CoinManager cm;

    public int points;
    float elapsedTime;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime * 10f;
        points = (int)elapsedTime + cm.runCoinCount * 10;
        counter.text =  "Score:\n" + points;
    }

//new
    // public void getDepth(){
    //     return counter.text;
    // }

    // public void stopDepthTracking(){
    //     elapsedTime = 0;
    // }
}
