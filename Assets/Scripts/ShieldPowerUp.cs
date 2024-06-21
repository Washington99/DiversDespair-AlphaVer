using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShieldPowerUp : MonoBehaviour
{
    [SerializeField] private float shieldDuration;
    [SerializeField] private float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Code for moving across screen
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();


        if (player != null)
        {
            player.StartCoroutine("ShieldPowerUp", shieldDuration);

            Destroy(gameObject);

            // Disable the collider to prevent further collisions while it explodes 

            // Explode animation

            // Start the coroutine to destroy the bomb after the animation (no animation yet)
        }

    }
}
