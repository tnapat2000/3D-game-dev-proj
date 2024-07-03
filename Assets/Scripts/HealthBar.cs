using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHP(int hp) {
        slider.maxValue = hp;
        slider.value = hp;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int hp) {
        slider.value = hp; 
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
