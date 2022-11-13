using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    

public class enemyScript : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
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
