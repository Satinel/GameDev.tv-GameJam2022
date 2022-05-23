using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    int damage;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Swipe()
    {
        if (Input.GetButton("Fire1"))
        {
            animator.SetBool("isSwiping", true);

            //TODO play Swipe animation
            //TODO cause an attack somehow
            Debug.Log("You swiped");
        }
        else
        {
            animator.SetBool("isSwiping", false);
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
