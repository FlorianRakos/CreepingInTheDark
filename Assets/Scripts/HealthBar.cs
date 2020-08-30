using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;

    void Start()
    {
        healthBar.fillAmount = 1;
    }


    public void adjustHealthbar(float health) {
        healthBar.fillAmount = health / 100f;
    }
}
