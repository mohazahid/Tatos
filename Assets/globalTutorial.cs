using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class globalTutorial : MonoBehaviour
{
    GameObject[] PotatoCount;
    GameObject[] LanturnCheck;
    bool FlashorLan = false;
    public TMP_Text statText;
    public AudioClip[] ambient;
    public GameObject Flashlight;
    public GameObject Lanturn;
  
    int potatoCheck;
    private int PotatoCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = ambient[0];
        GetComponent<AudioSource>().Play();
        PotatoCount = GameObject.FindGameObjectsWithTag("Collectible");
        potatoCheck = PotatoCount.Length;
    }

    // Update is called once per frame
    void Update()
    {
        LanturnCheck = GameObject.FindGameObjectsWithTag("Lanturn");
        PotatoCount = GameObject.FindGameObjectsWithTag("Collectible");
        if (LanturnCheck.Length == 0)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                if (FlashorLan == false)
                {
                    FlashorLan = true;
                }
                else
                {
                    FlashorLan = false;
                }
                LightChoice();
            }
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                if (FlashorLan == false)
                {
                    FlashorLan = true;
                }
                else
                {
                    FlashorLan = false;
                }
                LightChoice();
            }
        }

            if (PotatoCount.Length != potatoCheck)
            {
                PotatoCounter++;
                potatoCheck = PotatoCount.Length;
            }
        statText.SetText(PotatoCounter + "/1");
    }

    void LightChoice()
    {
        if (FlashorLan == true)
        {
            Flashlight.SetActive(false);
            Lanturn.SetActive(true);
        }
        else
        {
            Flashlight.SetActive(true);
            Lanturn.SetActive(false);
        }
    }
}
