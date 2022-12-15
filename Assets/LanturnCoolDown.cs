using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LanturnCoolDown : MonoBehaviour
{
    // Start is called before the first frame update
    public Image LanturnImage;
    public float coolDownValue = 0f;
    public static float maxCoolDownValue = 5f;
    public float coolDownTime = 5f;
    void Start()
    {
        LanturnImage.fillAmount = 0f;
        LanturnImage.fillAmount = coolDownValue;
        maxCoolDownValue = 5f;
    }

    // Update is called once per frame
    public void activateCoolDownEffect()
    {
        if (coolDownValue <= 1f)
        {
            coolDownValue += 1f / coolDownTime * Time.deltaTime;
            LanturnImage.fillAmount = coolDownValue;
        }
        else
        {
            coolDownValue = 1f;
            Global.isCoolDown = true;
            globalTutorial.isCoolDown = true;
            LanturnImage.fillAmount = maxCoolDownValue;
        }
    }
    public void resetCoolDownEffect()
    {
        if (coolDownValue > 0f)
        {
            coolDownValue -= .7f / coolDownTime * Time.deltaTime;
            LanturnImage.fillAmount = coolDownValue;
        }
        else
        {
            coolDownValue = 0f;
            Global.isCoolDown = false;
            globalTutorial.isCoolDown = false;
            LanturnImage.fillAmount = 0f;
        }
    }

}
