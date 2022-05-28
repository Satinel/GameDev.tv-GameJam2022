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
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        currentSize = 1;
        maxHealth = 3;
        hitPoints = maxHealth;
        stomachSize = 10;
        stomachLevel = 0;
        transform.localScale = new Vector3(0.125f,0.125f,0.125f);
        mainCamera.transform.localPosition = new Vector3 (0, 1.25f, -2.125f);
        SendMessageUpwards("ReclampRange", SendMessageOptions.RequireReceiver);
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
        if (isInvincible)
        {
            return;
        }
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            //TODO PlayerDeath method
            Debug.Log("You Died");
            //TODO make a life depletion method
            //BecomeGhost();
            return;
        }
        animator.SetTrigger("tookDamage");
        //TODO Play a sound
        isInvincible = true;
        Invoke("StopInvincibility", 1.5f);
    }

    void StopInvincibility()
    {
        isInvincible = false;
    }


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
        Debug.Log(currentSize);
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
