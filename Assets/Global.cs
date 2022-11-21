using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Global : MonoBehaviour
{
    GameObject[] PotatoCount;
    GameObject[] LanturnCheck;
    bool FlashorLan = false;
    public TMP_Text statText;
    private double msgTimer = 1f;
    public AudioClip[] ambient;
    public GameObject Flashlight;
    public GameObject Lanturn;
    public GameObject FinalPotato;
    public GameObject Finalmsg;
    bool ranMsg = false;
    int potatoCheck;
    private int PotatoCounter = 0;
    public static bool finalPotatoActive = false;    
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
         if (PotatoCount.Length <= 4)
        {
            GetComponent<AudioSource>().clip = ambient[1];

            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        if (PotatoCount.Length == 0)
        {
            PotatoCounter++;
            potatoCheck = 1;
        }
        else
        {
            if (PotatoCount.Length != potatoCheck)
            {
                PotatoCounter++;
                potatoCheck = PotatoCount.Length;
            }
        }
        if (PotatoCount.Length == 0 && !ranMsg)
        {
            FinalPotato.SetActive(true);
            FinalMessage();
            ranMsg = true;
        }

        statText.SetText(PotatoCounter + "/8");
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
    void FinalMessage()
    {
        Finalmsg.SetActive(true);
        if (msgTimer == 0)
        {
            Finalmsg.SetActive(false);
        }
        else
        {
            msgTimer -= 1 * Time.deltaTime;
        }
    }
}
