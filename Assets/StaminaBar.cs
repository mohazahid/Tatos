using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider StamSlider;
    public float Stamina;
    public float maxStamina= 100;
    private WaitForSeconds regenTick = new WaitForSeconds(.1f);
    private Coroutine regen;

    // Start is called before the first frame update
    void Start()
    {
        Stamina = maxStamina;
        StamSlider.maxValue = maxStamina;
        StamSlider.value = maxStamina;
    }

    public void UseStamina(float amount) {
        if(Stamina - amount >= 0) {
            Stamina -= amount;
            StamSlider.value = Stamina;
            if (regen != null) {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        } else {
            Debug.Log("Not enough stamina");
        }
    }
    private IEnumerator RegenStamina () {
       yield return new WaitForSeconds(2);

       while (Stamina < maxStamina) {
        Stamina += maxStamina/100;
        Debug.Log(Stamina);
        StamSlider.value = Stamina;
        yield return regenTick;

       }
       regen = null;
    }
}
