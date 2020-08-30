using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodSplatter : MonoBehaviour
{
    [SerializeField] Image bloodSpatterPrefab;
    [SerializeField] float xMin;
    [SerializeField] float xMax;
    [SerializeField] float yMin;
    [SerializeField] float yMax;


    public void paintBloodSplatter() {
        float x = Random.Range(xMin, xMax);
        float y = Random.Range(yMin, yMax);
        Vector3 randomPos = new Vector3 (x, y, 0f);

        Image bloodSpaltter = Instantiate(bloodSpatterPrefab) as Image;
        bloodSpaltter.transform.SetParent (gameObject.transform, false);
        bloodSpaltter.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0, 360));
        bloodSpaltter.transform.position = randomPos;

        StartCoroutine(FadeOutBlood(bloodSpaltter)) ;

    }


    IEnumerator FadeOutBlood(Image splatter) {

        yield return new WaitForSeconds(2f);
        splatter.CrossFadeColor(new Color (0f, 0f, 0f, 0f), 4f, true, true);    
        Destroy(splatter.gameObject, 4f);

    }
}
