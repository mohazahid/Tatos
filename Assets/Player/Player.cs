using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public double times = .2;
    Animator anim;
    private int rockCount = 0;  
    private int rockCountMax = 5;
    private int Health = 100;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
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

        anim.SetBool("Walking",Walking);
        if (Walking) {
            anim.SetFloat("x", input_x);
            anim.SetFloat("y", input_y);
        }
         if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= 15;
            healthBar.SetHealth(currentHealth);
        }
    }
 
    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * speed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.tag == "Rock") {
           rockCount++;
           if (rockCount >= rockCountMax) {
           }
       } 
       if (other.gameObject.tag == "Enemy") {
           Health -= 20;
       }    
        if (Health <= 0) {
            // Game Over
        }   
    }


}
