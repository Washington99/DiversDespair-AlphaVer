using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClamp : MonoBehaviour
{
    
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    private void LateUpdate() {
        
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -screenBounds.x * (float)0.8, screenBounds.x * (float)0.8);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y, screenBounds.y);
        transform.position = viewPos;


        // Debug.Log("Screen Bounds: " + screenBounds);
        // Debug.Log("x: " + viewPos.x);
        // Debug.Log("y: " + viewPos.y);

    }
}
