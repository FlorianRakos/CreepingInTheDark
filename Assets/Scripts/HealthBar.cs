using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void adjustHealthbar(float health) {
        healthBar.fillAmount = health / 100f;
    }
}
