using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    int damage;
    void Start()
    {
        
    }

    void Swipe()
    {
        if (Input.GetButton("Fire1"))
        {
            
            //if (!swipeanimation.isplaying)
            // {
                //TODO play Swipe animation
                //TODO cause an attack somehow
                Debug.Log("You swiped");
            // }
        }

    }

    void Bite()
    {
        if (Input.GetButton("Fire2"))
        {
            //TODO play Bite animation
            Debug.Log("You bit");
        }
        
    }
    
    void Update()
    {
        Swipe();
        Bite();
    }
}
