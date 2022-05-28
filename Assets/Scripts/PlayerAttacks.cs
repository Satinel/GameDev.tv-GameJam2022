using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    // [SerializeField] float baseDamage = 1;
    // [SerializeField] Transform swipeAOE;
    // [SerializeField] Transform biteAOE;
    // [SerializeField] float swipeRange = 3f;
    // [SerializeField] float biteRange = 1f;
    // [SerializeField] LayerMask enemyLayer;
    Animator animator;
    PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    void ToggleMovement()
    {
        if (playerMovement.isAttacking)
        {
            playerMovement.isAttacking = false;
        }
        else
        {
            playerMovement.isAttacking = true;
        }
    }

    void MovementOn()
    {
        playerMovement.isAttacking = false;
    }

    void MovementOff()
    {
        playerMovement.isAttacking = true;
    }

    void Swipe()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("swiping");
            //TODO play a sound
        }
    }

    void Bite()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("biting");
        }
    }
    
    void Update()
    {
        Swipe();
        Bite();
    }
}
