using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class Global : MonoBehaviour
{
    GameObject[] remaining;
    GameObject[] LanturnCheck;
    bool FlashorLan = false;
    public TMP_Text statText;

    public GameObject Flashlight;
    public GameObject Lanturn;

    public AudioClip[] ambient;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = ambient[0];
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        LanturnCheck = GameObject.FindGameObjectsWithTag("Lanturn");  
        remaining = GameObject.FindGameObjectsWithTag("Collectible");
        if (LanturnCheck.Length == 0) {
            if(Input.GetKeyDown("f")) {
                if (FlashorLan == false) {
                    FlashorLan = true;
                } else {
                    FlashorLan = false;
                }   
                LightChoice();
            }
        }
        
        statText.SetText((8-remaining.Length) + "/8");

        //change ambient sound
        if (remaining.Length <= 4)
        {
            GetComponent<AudioSource>().clip = ambient[1];

            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
    }

    void LightChoice() {
        if (FlashorLan == true) {
            Flashlight.SetActive(false);
            Lanturn.SetActive(true); 
        } else {
            Flashlight.SetActive(true); 
            Lanturn.SetActive(false);   
        }   
    }
}
