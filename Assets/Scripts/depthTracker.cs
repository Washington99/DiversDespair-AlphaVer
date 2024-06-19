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
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        points = Mathf.FloorToInt(elapsedTime);
        counter.text =  "Depth:\n" + points * 10 + " m";
    }

//new
    // public void getDepth(){
    //     return counter.text;
    // }

    // public void stopDepthTracking(){
    //     elapsedTime = 0;
    // }
}
