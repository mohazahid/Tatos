using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyMove : MonoBehaviour
{
    private AIPath aiPath;
    private float Globalspeed;
    // Start is called before the first frame update
    void Start()
    {
        aiPath = this.GetComponent<AIPath>();
        Globalspeed = aiPath.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log(aiPath.maxSpeed);
        if(!(aiPath.maxSpeed <=0))
        aiPath.maxSpeed = (Globalspeed-5);
        Globalspeed = aiPath.maxSpeed;
    }
}
