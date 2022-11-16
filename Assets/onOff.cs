using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onOff : MonoBehaviour
{
	GameObject[] LanturnCheck;
	Vector3 mouse_pos;
	public GameObject[] objects;
    private GameObject lightObject;
    new UnityEngine.Rendering.Universal.Light2D light;

	// Use this for initialization
	void Start () {
        lightObject = GameObject.Find("Flashlight");
		light = lightObject.GetComponent<UnityEngine.Rendering.Universal.Light2D> ();
		
	}

	// Update is called once per frame
	void Update () {
		// Toggle light on/off when L key is pressed.
		LanturnCheck = GameObject.FindGameObjectsWithTag("Lanturn");
		if (Input.GetKeyDown("f") && LanturnCheck.Length >= 1) {
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
