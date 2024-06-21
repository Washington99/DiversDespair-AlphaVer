using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class HypnoFish : MonoBehaviour
{
    public float scrollSpeed;
    //private Animator myAnimator;
    private Collider2D myCollider;
    private PlayerMovement player;
    [SerializeField] private float hypnotizeDuration;
    AudioManager audioManager;

    private void Awake(){
        //audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //myAnimator = GetComponent<Animator>();
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
            player.StartCoroutine("Hypnotize", hypnotizeDuration);

            Destroy(gameObject);

            // Disable the collider to prevent further collisions while it explodes 

            // Explode animation

            // Start the coroutine to destroy the bomb after the animation (no animation yet)
        }

    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait until the animation completes

        yield return new WaitForSeconds(0.5f);

        // Destroy the bomb object
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
