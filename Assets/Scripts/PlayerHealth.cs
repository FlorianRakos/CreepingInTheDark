using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float healthPoints = 100f;
    [SerializeField] Canvas bloodCanvas;
    [SerializeField] float bloodVanishTime = 100f;
    Image[] bloodCanvasChildren;
        int currentBloodCanvas = 0;
        int length;



    // Start is called before the first frame update
    void Start()
    {
        bloodCanvasChildren = bloodCanvas.GetComponentsInChildren<Image>();
        length = bloodCanvasChildren.Length;
        RemoveBloodFX();       
    }

    private void RemoveBloodFX()
    {
        foreach(Image bloodImage in bloodCanvasChildren) {
            bloodImage.color = new Color32(255, 255, 255, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FindObjectOfType<HealthBar>().adjustHealthbar(healthPoints);
    }



    public void TakeDamage (float damage) {
    healthPoints -= damage;
    StartCoroutine(bloodFX());
    

    if (healthPoints <= 0) {
        GetComponent<DeathHandler>().HandlePlayerDeath();
    }
    }

    IEnumerator bloodFX () {
        // blood.gameObject.SetActive(true);
        // yield return new WaitForSeconds(.3f);
        // blood.gameObject.SetActive(false);

        bloodCanvasChildren[currentBloodCanvas].color = new Color (255, 255, 255, 255);
        FadeOutBlood(bloodCanvasChildren[currentBloodCanvas]);
        if(currentBloodCanvas >= length -1) {
            currentBloodCanvas = 0;
        } else {
          currentBloodCanvas ++;  
        }
        
        yield return new WaitForSeconds(0);

    }

    private void FadeOutBlood(Image bloodImage)
    {

        bloodImage.CrossFadeColor(new Color (1f, 1f, 1f, 0f), 3f, true, true);
            
    
    }

}
