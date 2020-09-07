using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [SerializeField] float chargeDecay = .02f;
    [SerializeField] float charge = 1f;

    bool lightActive = true;
    float brightness;
    Light myLight;

    void Start()
    {
        myLight = GetComponent<Light>();
        brightness = myLight.intensity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (lightActive)
            {
                lightActive = false;
            }
            else
            {
                lightActive = true;
            }
        }

        if (lightActive)
        {
            myLight.enabled = true;
            charge -= (chargeDecay * Time.deltaTime);
            myLight.intensity = brightness * charge;

        }
        else
        {
            myLight.enabled = false;
        }

        FindObjectOfType<BatteryBar>().adjustBatteryBar(charge);
    }

    public void IncreaseBatteryCharge()
    {
        charge = 1f;
    }
}
