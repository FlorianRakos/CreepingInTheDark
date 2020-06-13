using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    Camera camera;
    [SerializeField] float FOVNormal = 60f;
    [SerializeField] float FOVZoomed = 30f;
    [SerializeField] float SensitivityNormal = 2f;
    [SerializeField] float SensitivityZoomed = 1f;

    [SerializeField] RigidbodyFirstPersonController fpsController;
    

    bool zoomedIn = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();

        
    }

  
    void Update() {

        if(Input.GetMouseButtonDown(1)) {
            SwitchFOV();
        }
    }

    private void SwitchFOV()
    {
        if (!zoomedIn) {
            zoomedIn = true;
            camera.fieldOfView = FOVZoomed;
            fpsController.mouseLook.XSensitivity = SensitivityZoomed;
            fpsController.mouseLook.YSensitivity = SensitivityZoomed;
            
        } else {
            zoomedIn = false;
            camera.fieldOfView = FOVNormal;
            fpsController.mouseLook.XSensitivity = SensitivityNormal;
            fpsController.mouseLook.YSensitivity = SensitivityNormal;

        }
    }
}
