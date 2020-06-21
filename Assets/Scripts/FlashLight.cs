using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    [SerializeField] float lightdecay = .02f;
    [SerializeField] float charge = 1f;
    [SerializeField] float flashingTime = .2f;
    bool lightActive = true;

    float brightness;
    Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        brightness = myLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) {
            if (lightActive) {
               lightActive = false; 
            } else {
                lightActive = true;
            }
        }

        if (lightActive) {
            myLight.enabled = true;
            charge -= (lightdecay * Time.deltaTime);
            myLight.intensity = brightness * charge;

        } else {
            myLight.enabled = false;
        }

        if (charge <= .2) {
            
            //StartCoroutine(LightFlashing());
        }
        
    }

    IEnumerator LightFlashing () {
        
        myLight.enabled = false;
        yield return new WaitForSeconds(flashingTime);
        myLight.enabled = true;
    }

    public void IncreaseBatteryCharge () {
        charge = 1f;
    }
}
