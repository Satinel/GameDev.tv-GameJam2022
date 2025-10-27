using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform playerTarget;
    [SerializeField] float speed = 0.5f;
    [SerializeField] float aggroRange = 15;
    [SerializeField] float attackRange = 1;
    [SerializeField] AudioClip attackSFX;
    [SerializeField] AudioClip hurtSFX;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource hurtAudioSource;
    Enemy livingVersion;
    Food deadVersion;
    float startingYPosition;
    float distanceToPlayer = Mathf.Infinity;
    Animator animator;
    Rigidbody rboi;
    

    void Start()
    {
        startingYPosition = transform.position.y;
        animator = GetComponent<Animator>();
        livingVersion = GetComponentInChildren<Enemy>();
        deadVersion = GetComponentInChildren<Food>();
        deadVersion.gameObject.SetActive(false);
        rboi = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Aggro()
    {
        distanceToPlayer = Vector3.Distance(playerTarget.position, transform.position);
        if (distanceToPlayer <= attackRange)
        {
            // animator.SetBool("isAggro", false);
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
                                            startingYPosition, transform.position.z);
        }
        else
        {
            animator.SetBool("inRange", false);
            animator.SetBool("isAggro", false);
        }
    }

    public void BecomeFood()
    {
        deadVersion.gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x,
                                        startingYPosition, transform.position.z);
        transform.rotation = new Quaternion(0, transform.rotation.y, 0, 0);
    }

    public void Respawn()
    {
        livingVersion.gameObject.SetActive(true);
    }

    void PlayAttackSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.PlayOneShot(attackSFX);
    }
       void PlayHurtSound()
    {
        if (hurtAudioSource.isPlaying)
        {
            hurtAudioSource.Stop();
        }
        hurtAudioSource.PlayOneShot(hurtSFX);
    }

    void Update()
    {

        if (livingVersion.gameObject.activeInHierarchy)
        {
            Aggro();
        }
        if (!livingVersion.gameObject.activeInHierarchy)
        {
            animator.SetBool("inRange", false);
            animator.SetBool("isAggro", false);
        }
    }
    
    void FixedUpdate()
    {
        if (deadVersion.gameObject.activeInHierarchy)
        {
            rboi.linearVelocity = Vector3.zero;
            rboi.angularVelocity = Vector3.zero;
        }
        if (distanceToPlayer > aggroRange)
        {
            rboi.linearVelocity = Vector3.zero;
            rboi.angularVelocity = Vector3.zero;
        }
    }

}
