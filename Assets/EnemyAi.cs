using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class EnemyAi : MonoBehaviour
{
    public Transform target; // the target object   
    public float speed = (100); //speed of enemy     
    public float nextWaypointDistance = 1f;     //distance between waypoints    
    Path path;  //path to follow    
    int currentWaypoint = 0;    //current waypoint
    bool reachedEndOfPath = false;  //if reached end of path    
    Seeker seeker;  //seeker component  
    Rigidbody2D rb; //rigidbody component   

    // Start is called before the first frame update
    void Start()
    {
        seeker = this.GetComponent<Seeker>(); //get seeker component
        rb = this.GetComponent<Rigidbody2D>();    //get rigidbody component  
        InvokeRepeating("UpdatePath", 0f, 0.5f);   //invoke UpdatePath every 0.5 seconds    
    }
    void UpdatePath() {
        if(seeker.IsDone()) {   //if seeker is done
            seeker.StartPath(rb.position, target.position,  OnPathComplete); //start pathfinding
        }   
        seeker.StartPath(rb.position, target.position,  OnPathComplete); //start pathfinding

    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) {
            return;
        }

    if(currentWaypoint >= path.vectorPath.Count)
    {
        reachedEndOfPath = true;
        return;
    }
    else
    {
        reachedEndOfPath = false;
    }   
    Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; //get direction to next waypoint
    Vector2 force = direction * speed * Time.deltaTime; //calculate force to apply
    rb.AddForce(force); //apply force to rigidbody
    float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]); //get distance to next waypoint   
    if (distance < nextWaypointDistance)
    {
        currentWaypoint++;  
    }
    
    }
}   
