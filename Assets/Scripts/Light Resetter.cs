using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightResetter : MonoBehaviour
{
    AudioManager audioManager;

    public float scrollSpeed;

    private void Awake(){
         audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        
        PlayerLight player = collider.gameObject.GetComponentInChildren<PlayerLight>();

        if (player != null)
        {
            Debug.Log("ResetLight");
            player.LightResetter();
            Destroy(gameObject);
        }
    }
}
