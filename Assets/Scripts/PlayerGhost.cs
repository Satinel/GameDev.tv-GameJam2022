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
        if (other.gameObject.tag == "Exit")
        {
            //TODO message to player than you need to possess a rat first
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Host")
        {
            canPossess = false;
        }
    }

    
    void PossessHost()
    {
        Destroy(host);
        canPossess = false;
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
