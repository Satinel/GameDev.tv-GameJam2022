using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] int hitPoints;
    [SerializeField] int stomachLevel;
    [SerializeField] int stomachSize = 10;
    [SerializeField] int currentSize = 1;
    [SerializeField] int requirementIncrease = 5;
    
    //TODO make player health/level/size/etc. display in playerUI
    // [SerializeField] Canvas playerUI;
    [SerializeField] Camera mainCamera;
    Animator animator;
    bool isSquished = false;
    bool isInvincible;


    void Start()
    {
        hitPoints = maxHealth;
        stomachLevel = 0;
        animator = GetComponent<Animator>();
    }
    public void IncreaseHealth()
    {
        if (hitPoints < maxHealth)
        {
            hitPoints++;
        }
    }

    public void DecreaseHealth(int damage)
    {
        if (isSquished)
        {
            return;
        }
        hitPoints -= damage;
        animator.SetTrigger("tookDamage");
        //TODO Move player back (if it doesn't mess everything up)
        //TODO Play a sound
        // StartCoroutine("iFrames");
        if(hitPoints <= 0)
        {
            Debug.Log("You Died");
            //TODO make a life depletion method
            //BecomeGhost();
        }
    }

    // IEnumerator iFrames()
    // {
    //     isInvincible = true;
    //     //TODO actually make iframes coroutine somehow
    //     isInvincible = false;
    //     return null;
    // }

    public void GainFood(int foodValue)
    {
        stomachLevel += foodValue;
    }

    void IncreaseSize()
    {
        if (currentSize < 5)
        {
            currentSize++;
            stomachSize += currentSize * requirementIncrease;
            SendMessageUpwards("ReclampRange", SendMessageOptions.RequireReceiver);
            maxHealth++;
            hitPoints++;
            transform.localScale *= 2;
            mainCamera.transform.localPosition *= 2; //mainCamera.transform.position * 2;
        }
    }

    public int GetCurrentSize()
    {
        return currentSize;
    }
    
    public void SquishThatRat()
    {
        if (!isSquished)
        {
            float originalSizeX = transform.localScale.x;
            float originalSizeY = transform.localScale.y;
            float originalSizeZ = transform.localScale.z;
            transform.localScale = new Vector3(originalSizeX, originalSizeY*0.1f, originalSizeZ);
            isSquished = true;
            Invoke("Unsquish", 2f);
        }
    }

    void Unsquish()
    {
        float originalSizeX = transform.localScale.x;
        float originalSizeY = transform.localScale.y;
        float originalSizeZ = transform.localScale.z;
        transform.localScale = new Vector3(originalSizeX, originalSizeY*10f, originalSizeZ);
        isSquished = false;
    }
    

    
    void Update()
    {
        if (stomachLevel >= stomachSize && !isSquished)
        {
            IncreaseSize();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            IncreaseSize();
        }
    }
}
