using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    Vector3 mouse_pos;
    public Player player;
    public playerTutorial playerTutorial;
    public GameObject rock;
    public Transform RockTransform;      
    private double timer;  
    // Start is called before the first frame update
    void Start()
    {
        timer = .2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null) {
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		mouse_pos.Normalize();
		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f,angle);
        if(Input.GetMouseButton(0) && playerTutorial.rockCount > 0 ){
            rockShootTutorial();
     	}
        } else {

        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		mouse_pos.Normalize();
		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f,angle);
        if(Input.GetMouseButton(0) && player.rockCount > 0 ){
            rockShoot();
     	}
        }
    }

    void rockShoot() {
        timer -= 1 * Time.deltaTime;
        if(timer <= 0){
            Instantiate(rock, RockTransform.position , Quaternion.identity);
            player.rockCount -= 1;
            timer = .2f;
        }
    }
    void rockShootTutorial() {
        timer -= 1 * Time.deltaTime;
        if(timer <= 0){
            Instantiate(rock, RockTransform.position , Quaternion.identity);
            playerTutorial.rockCount -= 1;
            timer = .2f;
        }
    }
}