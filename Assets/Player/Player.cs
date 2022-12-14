using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int randInt;
    public double times = .2;
    private double HealthTimer = 0;
    public static int potatoCount = 0;
    Animator anim;
    private AudioSource playerSound;
    public int rockCount;
    private int rockCountMax = 5;
    public int maxHealth = 100;
    public int currentHealth;
    public TMP_Text RockValue;
    public HealthBar healthBar;
    public AudioClip[] footsteps;
    public GameObject Hurt;
    private AudioSource HurtAudio;
    public StaminaBar staminaBar;
    public static bool SprintCoolDown = false;
    // Add the variables
    public static float speed = 35f; // Speed variable
    public static float baseSpeed = 35f;
    public static float SprintSpeed = 60f;
    public Rigidbody2D rb; // Set the variable 'rb' as Rigibody
    public Vector2 movement; // Set the variable 'movement' as a Vector3 (x,y,z)

    // 'Start' Method run once at start for initialisation purposes
    void Start()
    {
        // find the Rigidbody of this game object and add it to the variable 'rb'
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerSound = GetComponent<AudioSource>();
        rockCount = 3;
        RockValue.text = rockCount.ToString() + "/5";
        HurtAudio = Hurt.GetComponent<AudioSource>();
        potatoCount = 0;
        SprintCoolDown = false;
        speed = 35f;
        baseSpeed = 35f;
        SprintSpeed = 60f;
    }


    // 'Update' Method is called once per frame
    void Update()
    {
        // In Update we get the Input for left, right, up and down and put it in the variable 'movement'...
        // We only get the input of x and z, y is left at 0 as it's not required
        // 'Normalized' diagonals to prevent faster movement when two inputs are used together
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        bool Walking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;
        RockValue.text = rockCount.ToString() + "/5";
        if (potatoCount == 8)
        {
            SceneManager.LoadScene("WinScreen");
        }
        anim.SetBool("Walking", Walking);
        if (Walking)
        {
            anim.SetFloat("x", input_x);
            anim.SetFloat("y", input_y);
            //play footstep sound
            playerSound.enabled = true;
            if (!playerSound.isPlaying)
            {
                randInt = Random.Range(0, footsteps.Length);
                playerSound.clip = footsteps[randInt];
                playerSound.Play();
            }
        }
        else
        {
            playerSound.enabled = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (staminaBar.Stamina > 0 && Walking) 
            {
                staminaBar.UseStamina(.15f);
            }
            else
            {
                speed = baseSpeed;
            }
        }
        else
        {
            speed = baseSpeed;
        }
    }

    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * speed * Time.deltaTime));
    }
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
        if (currentHealth <= 0)
        {

            SceneManager.LoadScene("EndScreen");

        }
    }
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SpawningRock")
        {
            if (rockCount < rockCountMax)
            {
                rockCount++;
            }
        }
        if (other.gameObject.tag == "Collectible")
        {
            potatoCount++;
        }
    }
    private void TakeDamage()
    {
        HealthTimer -= 1 * Time.deltaTime;
        if (HealthTimer <= 0)
        {
            currentHealth -= 10;
            HurtAudio.Play();
            healthBar.SetHealth(currentHealth);
            HealthTimer = .4;
        }

    }
}
