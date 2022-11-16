using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    [SerializeField]
    private TMP_Text HealthValue;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        HealthValue.text = health.ToString()+ "/100";
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        if (health < 10) {
            HealthValue.text = "0/100";
        } else {
            HealthValue.text = health.ToString()+ "/100";
        }
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
