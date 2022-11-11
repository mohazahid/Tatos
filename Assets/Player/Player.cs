using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public double times = .2;
    public GameObject prefab;
    Animator anim;

        // Add the variables
    public float speed = 100f; // Speed variable
    public Rigidbody2D rb; // Set the variable 'rb' as Rigibody
    public Vector2 movement; // Set the variable 'movement' as a Vector3 (x,y,z)
 
    // 'Start' Method run once at start for initialisation purposes
    void Start()
    {
        // find the Rigidbody of this game object and add it to the variable 'rb'
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
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
    }
 
    // 'FixedUpdate' Method is used for Physics movements
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (movement * speed * Time.deltaTime));
    }
 
 

    void EggShoot() {
        times -= 1 * Time.deltaTime;
        if(times <= 0){
            Instantiate(prefab, transform.position + (transform.forward*2), transform.rotation);
            times = .2f;
        }
    }
}
