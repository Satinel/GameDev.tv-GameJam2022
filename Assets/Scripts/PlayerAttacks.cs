using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] Transform swipeAOE;
    [SerializeField] int damage;
    [SerializeField] float swipeRange = 3f;
    [SerializeField] LayerMask enemyLayer;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Swipe()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            damage = 2;
            animator.SetTrigger("swiping");
            //TODO cause an attack somehow
            Collider[] enemiesHit = Physics.OverlapSphere(swipeAOE.position, swipeRange, enemyLayer);
            
            foreach (Collider enemyHit in enemiesHit)
            {
                Debug.Log("You swiped: " + enemyHit.name);
                enemyHit.GetComponent<Enemy>().getHit(damage);
            }
        }
    }

    // void OnDrawGizmos()
    // {
    //     if (swipeAOE == null) return;
    //     Gizmos.DrawWireSphere(swipeAOE.position, swipeRange);
    // }

    void Bite()
    {
        if (Input.GetButtonDown("Fire2"))
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
