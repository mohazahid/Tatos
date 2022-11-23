using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LantrunOn : MonoBehaviour
{
    new UnityEngine.Rendering.Universal.Light2D light;
    public GameObject Lanturn;
    // Start is called before the first frame update
    void Start()
    {
		light = Lanturn.GetComponent<UnityEngine.Rendering.Universal.Light2D> ();  
        light.enabled = true; 
    }
    void OnEnable() {
		light = Lanturn.GetComponent<UnityEngine.Rendering.Universal.Light2D> ();  
        light.enabled = true; 
	}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")) {
			light.enabled = !light.enabled;
		} else if (Input.GetKeyDown("f")){
			light.enabled = true;
		}	
    }
}
