using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    // Material material;

    void Start()
    {

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Host")
        {
            //TODO make particle effect play
            if (Input.GetButtonDown("Fire1"))
            {
                // material = other.GetComponentInChildren<Renderer>().material;
                other.GetComponent<BabyRat>().BecomeHost();
                PossessHost();
            }
        }
    }

    void PossessHost()
    {
        playerHealth.gameObject.SetActive(true);
        // playerHealth.GetComponent<Renderer>().material = material;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
