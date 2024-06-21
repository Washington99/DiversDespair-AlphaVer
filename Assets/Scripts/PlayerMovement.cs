using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float maxSpeed;
    private Rigidbody2D body;
    private Vector2 screenBounds;
    private float stamina;

    public bool isShieldPresent = false;

    // [SerializeField] private int shieldDuration;
    [SerializeField] private float maxStamina;

    [SerializeField] private float staminaDrain;
    [SerializeField] PlayerStamina staminaBar;
    private PlayerLight playerLight;
    private bool isDead;
    
    private Color spriteColor;

    public GameManagerScript gameManager;
    public CoinManager cm;

    private Animator myAnimator;

    public SkinSelector skinSelector;

    private AudioManager audioManager;

    //Inverts if hypnofish is touched
    public bool moveInverted;
    public ShieldMovement shield;

    private void Awake()
    {
        playerLight = GetComponentInChildren<PlayerLight>();
        body = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        maxSpeed = speed;
        moveInverted = false;

        stamina = maxStamina;

        staminaBar.UpdateStaminaBar(stamina, maxStamina);
        
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        myAnimator = GetComponent<Animator>();
        spriteColor = GetComponent<SpriteRenderer>().color;

    }

    private void Update()
    {
    
        Move();
        ClampVelocity();
        if (!isShieldPresent)
        {
            DrainStamina();
        }

        if (stamina <= 0 && !isDead)
        {
            isDead = true;
            myAnimator.SetTrigger("death");
            if (skinSelector.currentSkinIndex == 1)
            {
                audioManager.PlaySFX(audioManager.covenDrownSound);
            }
            else if (skinSelector.currentSkinIndex == 2)
            {
                audioManager.PlaySFX(audioManager.clownDrownSound);
            }
            else if (skinSelector.currentSkinIndex == 3)
            {
                audioManager.PlaySFX(audioManager.freminetDrownSound);
            }
            else if (skinSelector.currentSkinIndex == 7)
            {
                audioManager.PlaySFX(audioManager.fireflyDrownSound);
            }
            else
            {
                audioManager.PlaySFX(audioManager.drownSound);
            }
            StartCoroutine(DestroyAfterDeath());
        }
    }

    private void Move()
    {
        if(!moveInverted)
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        else
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * - speed, body.velocity.y);
        
        if (Input.GetKeyDown(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed * 2);
    }

    private void DrainStamina()
    {
        stamina -= staminaDrain * Time.deltaTime;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        staminaBar.UpdateStaminaBar(stamina, maxStamina);
    }

    private void ClampVelocity()
    {
        if (transform.position.x < -screenBounds.x || transform.position.x > screenBounds.x)
            body.velocity = new Vector2(0, body.velocity.y);
        if (transform.position.y < -screenBounds.y || transform.position.y > screenBounds.y)
            body.velocity = new Vector2(body.velocity.x, 0);
        if (body.velocity.y > maxSpeed)
            body.velocity = new Vector2(body.velocity.x, maxSpeed);
        if (body.velocity.y < -maxSpeed / 2)
            body.velocity = new Vector2(body.velocity.x, -maxSpeed / 2);
    }

    public void TakeDamage(float damage)
    {
        if (!isShieldPresent) {
            stamina -= damage;
            staminaBar.UpdateStaminaBar(stamina, maxStamina);
        }
    }

    public void HealStamina(float amount)
    {
        stamina += amount;
        stamina = Mathf.Clamp(stamina, 0, maxStamina);
        staminaBar.UpdateStaminaBar(stamina, maxStamina);
    }

    public void IncreaseCoinCount(int amount)
    {
        cm.AddCoins(amount);
    }

    private IEnumerator DestroyAfterDeath()
    {
        yield return new WaitForSeconds(2.0f);

        cm.SaveRunCoins();
        gameObject.SetActive(false);
        gameManager.gameOver();
    }

    public IEnumerator ShieldPowerUp(float shieldDuration)
    {
        isShieldPresent = true;
        shield.ShieldOn();
        
        yield return new WaitForSeconds(shieldDuration);

        isShieldPresent = false;
        shield.ShieldOff();
    }
    public IEnumerator ScoreMultiplierPowerUp(float scoreMultiplierDuration)
    {
        GetComponent<SpriteRenderer>().color = new Color32(255, 165, 0, 255);
        
        yield return new WaitForSeconds(scoreMultiplierDuration/10.0f);

        GetComponent<SpriteRenderer>().color = spriteColor;
    }

    private IEnumerator Hypnotize(float hypnotizeDuration)
    {
        float timeElapsed = 0f;
        
        body.velocity = new Vector2(-body.velocity.x, body.velocity.y);
        while (timeElapsed < hypnotizeDuration)
        {
            
            moveInverted = true;
            playerLight.changeInnerLightColor(Color.Lerp(Color.magenta, Color.white, timeElapsed / (hypnotizeDuration + 0.5f)));
            timeElapsed += Time.deltaTime;
            yield return null;
        };
        playerLight.changeInnerLightColor(Color.white);
        moveInverted = false;
    }
}
