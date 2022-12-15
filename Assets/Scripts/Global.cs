using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Global : MonoBehaviour
{
    GameObject[] LanturnCheck;
    bool FlashorLan = false;
    public TMP_Text statText;
    private double msgTimer = 5f;
    public GameObject Flashlight;
    public GameObject Lanturn;
    public GameObject LanturnGUI;
    public GameObject FlashlightImage;
    public GameObject LanturnImage;
    public GameObject FinalPotato;
    public GameObject Finalmsg;
    bool ranMsg = false;
    public static bool isCoolDown = false;
    public LanturnCoolDown LanturnCoolDown;
    public static bool finalPotatoActive = false;    
    // Start is called before the first frame update
    void Start()
    {
        isCoolDown = false;
        finalPotatoActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        LanturnCheck = GameObject.FindGameObjectsWithTag("Lanturn");
        if (LanturnCheck.Length == 0)
        {
            LanturnGUI.SetActive(true);
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
        if (Player.potatoCount == 7)
        {
            FinalPotato.SetActive(true);
            FinalMessage();
            ranMsg = true;
        }

        statText.SetText(Player.potatoCount + "/8");
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
    void FinalMessage()
    {
        Finalmsg.SetActive(true);
        if (msgTimer <= 0)
        {
            Finalmsg.SetActive(false);
        }
        else
        {
            msgTimer -= 1 * Time.deltaTime;
        }
    }
}
