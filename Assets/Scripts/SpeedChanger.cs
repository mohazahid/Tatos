using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class SpeedChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public AIPath aiPath;
    private float GlobalSpeed;
    private float speedHolder;
    GameObject[] PotatoCount;
    double timer;
    double stallTimer;
    int multiplyer;
    bool stallOn = false;
    int count = 8;
    void Start()
    {
        aiPath = this.GetComponent<AIPath>();
        GlobalSpeed = aiPath.maxSpeed;   
        if (ToggleDifficulty.difficulty == "Easy"){
            aiPath.maxSpeed = 40;
            aiPath.maxAcceleration = 25;    
            stallTimer = .4;  
            timer = .4;
        }
        else if (ToggleDifficulty.difficulty == "Normal"){
            aiPath.maxSpeed = 100;
            aiPath.maxAcceleration = 75; 
            stallTimer = .3;  
            timer = .3;
        }
        else if (ToggleDifficulty.difficulty == "Hard"){
            aiPath.maxSpeed = 120;
            aiPath.maxAcceleration = 100;
            stallTimer = .2;  
            timer = .2;
        }   
        int multiplyer =1;
        Debug.Log("SpeedChanger: " + aiPath.maxSpeed);
        speedHolder = aiPath.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        GlobalSpeed = aiPath.maxSpeed;
        PotatoCount = GameObject.FindGameObjectsWithTag("Collectible");
        if (PotatoCount.Length != count) {
            count--;
            multiplyer = 1+(8-PotatoCount.Length)/7;
            GlobalSpeed = speedHolder*multiplyer;
        }       
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") {
            
        } else if (other.gameObject.tag == "Rock") {
            aiPath.maxSpeed = 1;
            timer = stallTimer;   
            stallOn = true;
        }   
    }


    private void FixedUpdate() {       
        if(stallOn) {
            timer -= .5* Time.deltaTime;
            if (timer <= 0) {
                aiPath.maxSpeed = speedHolder*multiplyer;  
                stallOn = false;
            }
            Debug.Log(timer);
        }
    }
}
