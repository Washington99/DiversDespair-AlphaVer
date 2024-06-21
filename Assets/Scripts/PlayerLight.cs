using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerLight : MonoBehaviour
{

    private Light2D playerLight;
    [SerializeField] depthTracker dt;

    private float counter;
    // Start is called before the first frame update
    void Start() {
        playerLight = GetComponent<Light2D>();
        playerLight.pointLightOuterRadius = 12;
    }

    // Update is called once per frame
    void Update()
    {
        playerLight.pointLightOuterRadius = Mathf.Max(2, 12 - (dt.points-counter)*0.01f);
    }

    public void LightResetter() 
    {
        counter = dt.points;

    }

    public void changeInnerLightColor(Color color) {
        playerLight.color = color;
    }
}
