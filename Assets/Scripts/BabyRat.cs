using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyRat : MonoBehaviour
{
    bool invoked;

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
