using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject canvas;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
        canvas.SetActive(false);
    }

    public void UpdateHealth(float health)
    {
        StartCoroutine(ShowForATime());
        
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    private IEnumerator ShowForATime()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        canvas.SetActive(false);
    }
}
