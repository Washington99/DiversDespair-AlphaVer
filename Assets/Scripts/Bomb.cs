using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Bomb : MonoBehaviour
{
    public float scrollSpeed;
    private float damageAmount = 20f;
    private Animator myAnimator;
    private Collider2D myCollider;

    AudioManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement player = collider.GetComponent<PlayerMovement>();

        if (player != null)
        {
            audioManager.PlaySFX(audioManager.explosion);
            
            // Drain stamina
            player.TakeDamage(damageAmount);

            // Disable the collider to prevent further collisions while it explodes 
            myCollider.enabled = false;

            // Explode animation
            myAnimator.SetTrigger("collide");

            // Start the coroutine to destroy the bomb after the animation
            StartCoroutine(DestroyAfterAnimation());
        }
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait until the animation completes
        yield return new WaitForSeconds(0.5f);

        // Destroy the bomb object
        Destroy(gameObject);
    }
}
