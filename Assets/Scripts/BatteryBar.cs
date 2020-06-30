using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    [SerializeField] Image batteryBar;

    public void adjustBatteryBar (float charge) {
        batteryBar.fillAmount = charge;

        

    }
}
