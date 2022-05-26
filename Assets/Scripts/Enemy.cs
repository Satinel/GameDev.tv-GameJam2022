using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 50;
    [SerializeField] int hitPoints;
    Vector3 defaultPosition;
    Quaternion defaultRotation;
    EnemyBehaviour enemyBehaviour;
    Animator animator;

    void Awake()
    {
        defaultPosition = transform.parent.localPosition;
        defaultRotation = transform.parent.localRotation;
    }

    void Start()
    {
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
        animator = GetComponentInParent<Animator>();
    }

    void OnEnable()
    {
        transform.parent.localPosition = defaultPosition;
        transform.parent.localRotation = defaultRotation;
        hitPoints = maxHitpoints;
    }

    public void getHit(int damage)
    {
        hitPoints -= damage;
        animator.SetTrigger("tookDamage");
        //TODO Play a sound
        if(hitPoints <= 0)
        {
            enemyBehaviour.BecomeFood();
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
