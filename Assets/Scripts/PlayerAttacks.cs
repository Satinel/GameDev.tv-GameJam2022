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
        if (playerMovement.enabled)
        {
            playerMovement.enabled = false;
        }
        else
        {
            playerMovement.enabled = true;
        }
    }

    void Swipe()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("swiping");
            //TODO play a sound
        }
    }

    // void OnDrawGizmos()
    // {
        // if (biteAOE == null) return;
    //     Gizmos.DrawWireSphere(biteAOE.position, biteRange);
    // }

    void Bite()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetTrigger("biting");
            
        //     Collider[] enemiesHit = Physics.OverlapSphere(swipeAOE.position, swipeRange, enemyLayer);
        //     foreach (Collider enemyHit in enemiesHit)
        //     {
        //         Debug.Log("You bit: " + enemyHit.name);
        //         enemyHit.GetComponent<Enemy>().getHit(baseDamage);
        //     }
        }
    }
    
    void Update()
    {
        Swipe();
        Bite();
    }
}
