using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SpeedChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private AIPath aiPath;
    private float GlobalSpeed;
    GameObject[] PotatoCount;
    double timer;
    double stallTimer;
    int multiplyer;
    int count = 8;
    void Start()
    {
        aiPath = this.GetComponent<AIPath>();
        GlobalSpeed = aiPath.maxSpeed;   
        if (ToggleDifficulty.difficulty == "Easy"){
            aiPath.maxSpeed = 40;
            aiPath.maxAcceleration = 25;    
            stallTimer = 4;  
            timer = 4;
        }
        else if (ToggleDifficulty.difficulty == "Normal"){
            aiPath.maxSpeed = 100;
            aiPath.maxAcceleration = 75; 
            stallTimer = 2;  
        }
        else if (ToggleDifficulty.difficulty == "Hard"){
            aiPath.maxSpeed = 200;
            aiPath.maxAcceleration = 200; 
            stallTimer = 1;  
        }   
        int multiplyer =1;
        Debug.Log("SpeedChanger: " + aiPath.maxSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        aiPath.maxSpeed = GlobalSpeed;
        PotatoCount = GameObject.FindGameObjectsWithTag("Collectible");
        if (PotatoCount.Length != count) {
            count--;
            multiplyer = 1+(8-PotatoCount.Length)/10;
            GlobalSpeed*= multiplyer;
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
            Debug.Log(timer);    
            stall();
        }   
    }


    void stall() {
        timer -= 1* Time.deltaTime;
        if (timer <= 0) {
            aiPath.maxSpeed = GlobalSpeed;  
        }
    }
}
