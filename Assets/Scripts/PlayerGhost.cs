using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhost : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    bool canPossess;
    GameObject host;
    ParticleSystem wisps;
    // Material material;

    void Start()
    {
        wisps = GetComponent<ParticleSystem>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Host")
        {
            // material = other.GetComponentInChildren<Renderer>().material;
            host = other.gameObject;
            wisps.Play(true);
            canPossess = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        canPossess = false;
        wisps.Play(false);
    }
    
    void PossessHost()
    {
        Destroy(host);
        playerHealth.gameObject.SetActive(true);
        // playerHealth.GetComponent<Renderer>().material = material;
        gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canPossess)
            {
                PossessHost();
            }
        }
    }
}
