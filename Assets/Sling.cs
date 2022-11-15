using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sling : MonoBehaviour
{
    Vector3 mouse_pos;
    public GameObject rock;
    private float timer;
    public Transform RockTransform;        
    // Start is called before the first frame update
    void Start()
    {
        timer = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		mouse_pos.Normalize();
		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		Debug.Log(angle);	
		transform.rotation = Quaternion.Euler(0f, 0f,angle);
        if(Input.GetMouseButtonDown(0)){
			Instantiate(rock, RockTransform.position , Quaternion.identity);
     	}
    }
}
