using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOn : MonoBehaviour
{
	GameObject[] LanturnCheck;
	Vector3 mouse_pos;
	public GameObject[] objects;
    public GameObject flashObject;
    new UnityEngine.Rendering.Universal.Light2D light;

	// Use this for initialization
	void Start () {
        light = flashObject.GetComponent<UnityEngine.Rendering.Universal.Light2D> ();  
        light.enabled = true; 
	}
	void OnEnable() {
		light = flashObject.GetComponent<UnityEngine.Rendering.Universal.Light2D> ();  
        light.enabled = true; 
	}
	// Update is called once per frame
	void Update () {
		// Toggle light on/off when L key is pressed.
		if (Input.GetKeyDown("f")) {
			light.enabled = !light.enabled;
		} else if (Input.GetKeyDown("f")){
			light.enabled = true;
		}	

	}
	 void FixedUpdate()
     {
    	mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		mouse_pos.Normalize();
		float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f,angle);
	}
}
