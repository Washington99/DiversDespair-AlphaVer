using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This code is not yet handling multiplying the score gained
when collecting coins.

At the moment, when a score multiplier powerup is instantiated
it could be either times 2 or times 3:
 - at less than 1000m, it is always times 2
 - else, there is 70% chance that it will be times 2 and
         remaining 30% chance that it will be times 3

This code also reflects the score multiplier to the depth
tracker object; specifically, the score gained is multiplied
by this score multiplier that is in effect for 25 seconds
*/

public class ScoreMultiplier : MonoBehaviour
{
    depthTracker depthTracker;
    AudioManager audioManager;
    
    [SerializeField] private float scrollSpeed;
    [SerializeField] private int multiplierDuration;
    private int scoreMultiplier;

    [SerializeField] Sprite scoreMultiplier3X;

    private void Awake()
    {
        depthTracker = (depthTracker) FindObjectOfType(typeof(depthTracker));  
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        if (depthTracker.points * 10 < 100)
            scoreMultiplier = 2;
        
        else
        {
            int randomSeed = Random.Range(1, 10);


            if (randomSeed <= 7)
            {
                // 70% chance to become times 2 multiplier
                scoreMultiplier = 2;
            }
            else
            {
                // remaining 30% chance to become times 3 multiplier
                scoreMultiplier = 3;
            }
        }

        if (scoreMultiplier == 3) {
            GetComponent<SpriteRenderer>().sprite = scoreMultiplier3X;
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
    }

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D (Collider2D collider) {

        PlayerMovement player = collider.GetComponent<PlayerMovement>();
            
        if (player != null) {
            player.StartCoroutine("ScoreMultiplierPowerUp", multiplierDuration);
            audioManager.PlaySFX(audioManager.powerUp);
            depthTracker.SetScoreMultiplier(scoreMultiplier, multiplierDuration);
            Destroy(gameObject);
        }
    }
}
