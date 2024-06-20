using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float scrollSpeed;
    
    //new
    AudioManager audioManager;
    private float damageAmount = 50f;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D (Collider2D collider) {

        PlayerMovement player = collider.GetComponent<PlayerMovement>();
            
        if (player != null) {

            
            audioManager.PlaySFX(audioManager.death);

            // Drain stamina
            player.TakeDamage(damageAmount);

            Destroy(gameObject);
              
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
