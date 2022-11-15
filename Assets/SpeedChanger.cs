using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SpeedChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private AIPath aiPath;
    private float GlobalSpeed;
    double timer;
    double stallTimer;
    void Start()
    {
        aiPath = this.GetComponent<AIPath>();
        GlobalSpeed = aiPath.maxSpeed;   
        stallTimer = 4;  
    }

    // Update is called once per frame
    void Update()
    {
        if (timer>0) {
            timer -= Time.deltaTime;    
        }
        else {
            aiPath.maxSpeed = GlobalSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(aiPath.maxSpeed); 
        //aiPath.maxSpeed = 1;
        if (other.gameObject.tag == "Player") {
            
        } else if (other.gameObject.tag == "Rock") {
            aiPath.maxSpeed = 0;
            timer = stallTimer;
            stall();
        }   
    }


    void stall() {
        aiPath.maxSpeed = 0;    
    }
}
