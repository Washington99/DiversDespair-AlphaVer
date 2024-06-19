using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    private float maxSpeed;
    private Rigidbody2D body;
    private Vector2 screenBounds;
    private float stamina;
    [SerializeField] private float maxStamina;
    
    [SerializeField] private float staminaDrain;
    [SerializeField] PlayerStamina staminaBar;

    //new
    private bool isDead;
    public GameManagerScript gameManager;
    // public depthTracker depthTracking;

    //coin count
    public CoinManager cm;

    //death animation
    private Animator myAnimator;

    //death sound
    AudioManager audioManager;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        maxSpeed = speed;

        stamina = maxStamina;
        staminaBar = GetComponentInChildren<PlayerStamina>();
        staminaBar.UpdateStaminaBar(stamina, maxStamina);

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        ClampVelocity();
        DrainStamina();

        //new
        if(stamina <= 0 && !isDead){
            isDead = true; 
            //death animation
            myAnimator.SetTrigger("death");
            audioManager.PlaySFX(audioManager.drownSound);
            StartCoroutine(DestroyAfterDeath());
            // depthTracking.
        }
    }

    private void Move() {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed * 2);
    }

    private void DrainStamina() {
        stamina -= staminaDrain * Time.deltaTime;
        staminaBar.UpdateStaminaBar(stamina, maxStamina);
    }

    private void ClampVelocity() {
        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x)
            body.velocity = new Vector2(0, body.velocity.y);
        if (transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
            body.velocity = new Vector2(body.velocity.x, 0);    
        if (body.velocity.y > maxSpeed)
            body.velocity = new Vector2(body.velocity.x, maxSpeed); 
        if (body.velocity.y < -maxSpeed / 2)
            body.velocity = new Vector2(body.velocity.x, -maxSpeed/2);
    }

    public void TakeDamage(float damage)
    {
        stamina -= damage;
        staminaBar.UpdateStaminaBar(stamina, maxStamina);
    }

    public void HealStamina(float amount)
    {
        if (stamina >0)
            stamina += amount;
            stamina = Mathf.Clamp(stamina, 0, maxStamina);
            staminaBar.UpdateStaminaBar(stamina, maxStamina);
    }

    public void IncreaseCoinCount(float amount)
    {
        cm.coinCount++;
    }

    private IEnumerator DestroyAfterDeath()
    {
        // Wait until the animation completes
        yield return new WaitForSeconds(2.0f);

        gameObject.SetActive(false);
        gameManager.gameOver();
    }
}