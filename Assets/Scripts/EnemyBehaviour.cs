using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float aggroRange = 15;
    [SerializeField] float attackRange = 1;
    // [SerializeField] float deaggroRange = 25;
    float distanceToPlayer = Mathf.Infinity;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Aggro()
    {
        distanceToPlayer = Vector3.Distance(playerTarget.position, transform.position);
        if (distanceToPlayer <= attackRange)
        {
            animator.SetBool("isAggro", false);
            animator.SetBool("inRange", true);
        }
        else if (distanceToPlayer <= aggroRange)
        {
            animator.SetBool("inRange", false);
            animator.SetBool("isAggro", true);
            transform.LookAt(playerTarget);
            transform.position = Vector3.MoveTowards(transform.position, 
                                                    playerTarget.position, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x,
                                                    2.5f, transform.position.z);
            // transform.(playerTarget.position.x,
            //                     0f, 
            //                     playerTarget.position.z);

        }
        else
        {
            animator.SetBool("inRange", false);
            animator.SetBool("isAggro", false);
        }
    }

    void Update()
    {
        Aggro();
    }

}
