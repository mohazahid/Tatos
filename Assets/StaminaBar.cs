using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider StamSlider;
    public float Stamina;
    public float maxStamina = 100;
    private WaitForSeconds regenTick = new WaitForSeconds(.1f);
    private Coroutine regen;

    // Start is called before the first frame update
    void Start()
    {
        Stamina = maxStamina;
        StamSlider.maxValue = maxStamina;
        StamSlider.value = maxStamina;
    }

    public void UseStamina(float amount)
    {
        if (Stamina - amount >= 0 && !Player.SprintCoolDown)
        {
            Stamina -= amount;
            StamSlider.value = Stamina;
            Player.speed = 60f;
            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
        else if (Stamina - amount <= 0)
        {
            Stamina = 0;
            StamSlider.value = Stamina;
            Player.SprintCoolDown = true;
        }
    }
    public void UseStaminaTutorial(float amount)
    {
        if (Stamina - amount >= 0 && !playerTutorial.SprintCoolDown)
        {
            Stamina -= amount;
            StamSlider.value = Stamina;
            playerTutorial.speed = 60f;
            if (regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
        else if (Stamina - amount <= 0)
        {
            Stamina = 0;
            StamSlider.value = Stamina;
            playerTutorial.SprintCoolDown = true;
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while (Stamina < maxStamina)
        {
            Stamina += maxStamina / 100;
            Debug.Log(Stamina);
            StamSlider.value = Stamina;
            yield return regenTick;
            if (Stamina >= maxStamina)
            {
                Player.SprintCoolDown = false;
                playerTutorial.SprintCoolDown = false;
            }
        }
        regen = null;
    }
}
