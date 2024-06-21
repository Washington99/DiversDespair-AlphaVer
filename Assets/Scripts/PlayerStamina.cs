using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Slider slider;
    //[SerializeField] private Vector3 offset;
    [SerializeField] private Image sliderFill;

    public void UpdateStaminaBar(float currentValue, float maxValue) {
        slider.value = currentValue / maxValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderFill.color = Color.Lerp(Color.red, Color.white, slider.value);
    }
    
}
