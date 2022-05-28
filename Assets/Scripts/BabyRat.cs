using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRat : MonoBehaviour
{
    bool invoked;
    [SerializeField] Material mat;

    void Start()
    {
        mat = GetComponentInChildren<Renderer>().material;
    }

    public void BecomeHost()
    {
        //return material source somehow
        Destroy(gameObject, 0.1f);
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
        invoked = false;
    }
}
