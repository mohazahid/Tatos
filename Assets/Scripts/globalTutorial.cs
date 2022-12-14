using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class globalTutorial : MonoBehaviour
{
    GameObject[] PotatoCount;
    GameObject[] LanturnCheck;
    bool FlashorLan = false;
    public TMP_Text statText;
    private double msgTimer = 5f;
    public AudioClip[] ambient;
    public GameObject Flashlight;
    public GameObject Lanturn;
    public GameObject LanturnGUI;
    public GameObject FlashlightImage;
    public GameObject LanturnImage;
    public GameObject LanturnTutorial;
    public bool Grabbed = true;
    public static bool isCoolDown = false;
    public LanturnCoolDown LanturnCoolDown;

    int potatoCheck;
    private int PotatoCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().clip = ambient[0];
        GetComponent<AudioSource>().Play();
        PotatoCount = GameObject.FindGameObjectsWithTag("Collectible");
        potatoCheck = PotatoCount.Length;
        isCoolDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        LanturnCheck = GameObject.FindGameObjectsWithTag("Lanturn");
        PotatoCount = GameObject.FindGameObjectsWithTag("Collectible");
        if (LanturnCheck.Length == 0 )
        {
            LanturnGUI.SetActive(true);
            if (Grabbed)
            {
                Time.timeScale = 0f;
                LanturnTutorial.SetActive(true);
                if (Input.GetKeyDown("e"))
                {
                    LanturnTutorial.SetActive(false);
                    Time.timeScale = 1f;
                    Grabbed = false;
                }
            }
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0 && !isCoolDown)
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
            else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0 && !isCoolDown)
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
            if (isCoolDown) {
                FlashorLan =false; 
                LightChoice();
            }
            if (FlashorLan) {
                LanturnCoolDown.activateCoolDownEffect();
            } else {
                LanturnCoolDown.resetCoolDownEffect();
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
            FlashlightImage.SetActive(false);
            
        }
        else
        {
            Flashlight.SetActive(true);
            Lanturn.SetActive(false);
            FlashlightImage.SetActive(true);
           
        }
    }
}
