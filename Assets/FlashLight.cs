using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour {

	public new UnityEngine.Rendering.Universal.Light2D light;

	// Use this for initialization
	void Start () {
		light = GetComponent<UnityEngine.Rendering.Universal.Light2D> ();
	}

	// Update is called once per frame
	void Update () {
		// Toggle light on/off when L key is pressed.
		if (Input.GetKeyDown("f")) {
			light.enabled = !light.enabled;
		}
	}
}