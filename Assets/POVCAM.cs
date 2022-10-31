using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POVCAM : MonoBehaviour
{
    public Image image;
    public Image Flash;
    private bool img;
    // Start is called before the first frame update
    void Start()
    {
    image = GetComponent<Image>();
    img = true;
    }

    // Update is called once per frame
    void Update() {        
        image.enabled = img;
        Flash.enabled = !img;
        if (Input.GetKeyDown(KeyCode.F)) {
            img = img ? false : true;
        }
    }
}
