using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ShieldMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float maxSpeed;
    private Rigidbody2D body;
    private Vector2 screenBounds;

    public bool isShieldPresent = false;

    // [SerializeField] private int shieldDuration;

    private bool isDead;

    private Color spriteColor;

    public GameManagerScript gameManager;

    private Animator myAnimator;

    public SkinSelector skinSelector;

    private AudioManager audioManager;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        maxSpeed = speed;


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
        }

    }

    private void Move()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed * 2);
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

    public IEnumerator ShieldPowerUp(float shieldDuration)
    {
        isShieldPresent = true;
        GetComponent<SpriteRenderer>().color = Color.green;

        yield return new WaitForSeconds(shieldDuration);

        isShieldPresent = false;
        GetComponent<SpriteRenderer>().color = spriteColor;
    }
}
