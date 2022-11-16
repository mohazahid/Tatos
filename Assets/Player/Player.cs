using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public double times = .2;
    int randInt;
    Animator anim;
    public int rockCount;
    private int rockCountMax = 5;
    private int Health = 100;
    private AudioSource playerSound;
    public int maxHealth = 100;
    public int currentHealth;
    public TMP_Text RockValue;
    public HealthBar healthBar;
    public AudioClip[] footsteps;
        // Add the variables
    private float speed = 75f; // Speed variable
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
        rockCount=3; 
        RockValue.text = rockCount.ToString()+ "/5";
        playerSound = GetComponent<AudioSource>();
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
        RockValue.text = rockCount.ToString()+ "/5";
        anim.SetBool("Walking",Walking);
        if (Walking) {
            anim.SetFloat("x", input_x);
            anim.SetFloat("y", input_y);

            // play footsteps
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
    }
 
    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "SpawningRock") {
           if (rockCount < rockCountMax) {
            rockCount++;
           }
       } 
       if (other.gameObject.tag == "Enemy") {
           currentHealth -= 20;
           healthBar.SetHealth(currentHealth);
       }    
        if (Health <= 0) {
            // Game Over
        }   
    }


}
