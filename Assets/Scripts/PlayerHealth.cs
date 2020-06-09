using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float healthPoints = 100f;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void TakeDamage (float damage) {
    healthPoints -= damage;
    if (healthPoints <= 0) {
        GetComponent<DeathHandler>().HandlePlayerDeath();
    }
    }

}
