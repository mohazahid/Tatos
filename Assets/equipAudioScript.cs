using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipAudioScript : MonoBehaviour
{
    private AudioSource Item;
    GameObject[] LanturnCheck;
    private bool hasPlayed = false;
    private bool FlashorLan = false;
    // Start is called before the first frame update
    void Start()
    {
        Item = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LanturnCheck = GameObject.FindGameObjectsWithTag("Lanturn");
        if (LanturnCheck.Length == 0)
        {
            if (hasPlayed == false)
            {
                Item.Play();
                hasPlayed = true;
            }
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                if (FlashorLan == false)
                {
                    FlashorLan = true;
                    Item.Play();
                }
                else
                {
                    FlashorLan = false;
                    Item.Play();
                }
                
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                if (FlashorLan == false)
                {
                    FlashorLan = true;
                    Item.Play();
                }
                else
                {
                    FlashorLan = false;
                    Item.Play();
                }
           
            }
        }
    }
}
