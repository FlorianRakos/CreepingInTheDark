using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    [SerializeField] Image batteryBar;

    public void adjustBatteryBar (float charge) {
        batteryBar.fillAmount = charge;        
        adjustColor(charge);
    }

    private void adjustColor (float charge) {
        if (charge > 0.5f) {
            float redValue = (1 - charge) * 2f; 
            batteryBar.color = new Color(redValue, 1, 0, 1);
        }
        if (charge < 0.5f) {
            float greenValue =  charge * 2f; 
            batteryBar.color = new Color(1, greenValue, 0, 1);
        }
        
    }

}
