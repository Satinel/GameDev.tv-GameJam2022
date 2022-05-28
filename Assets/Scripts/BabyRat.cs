using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRat : MonoBehaviour
{
    bool invoked;
    [SerializeField] int velocity = 2;
    [SerializeField] Material material;

    void Start()
    {
        material = GetComponentInChildren<Renderer>().material;
    }

    public void BecomeHost()
    {
        //return material source somehow
        Destroy(gameObject);
    }

    void Update()
    {
        if (!invoked)
        {
            Invoke("RandomMovement", UnityEngine.Random.Range(1, 10));
            invoked = true;
        }
    }

    void RandomMovement()
    {
        transform.Rotate(0, UnityEngine.Random.Range(1, 359), 0);
        //int randomRange = UnityEngine.Random.Range(1, 5);
        transform.position += transform.forward * velocity * Time.deltaTime; 
        invoked = false;
    }
}
