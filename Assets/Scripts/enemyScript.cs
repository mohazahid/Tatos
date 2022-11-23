using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class enemyScript : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        bool Walking = (Mathf.Abs(input_x) + Mathf.Abs(input_y)) > 0;
        
            anim.SetFloat("x", 0);
            anim.SetFloat("y", -1);
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("enter");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
            Debug.Log("Stay");
    }
}
