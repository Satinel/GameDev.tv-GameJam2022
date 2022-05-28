using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] int hitPoints;
    [SerializeField] int stomachSize = 10; // How much food it takes to fill your stomach
    [SerializeField] int stomachLevel; // How much food has been eaten
    [SerializeField] int requirementIncrease = 5; // How much the next stomach size increases by
    [SerializeField] int currentSize = 1; // The player's size level
    
    //TODO make player health/level/size/etc. display in playerUI
    [SerializeField] Transform dungeonPosition; // The main playing area
    [SerializeField] GameObject stomachUI;
    [SerializeField] Camera mainCamera;
    [SerializeField] PlayerGhost playerGhost;
    [SerializeField] GameObject heart0;
    [SerializeField] GameObject heart1;
    [SerializeField] GameObject heart2;
    [SerializeField] GameObject heart3;
    [SerializeField] GameObject heart4;
    [SerializeField] GameObject heart5;
    [SerializeField] GameObject heart6;
    Animator animator;
    Slider stomachSlider;
    RectTransform stomachBar;
    Vector3 sBarDefaultPos;
    Vector2 sBarDefaultSize;
    bool isSquished = false;
    bool isInvincible;
    


    void Start()
    {
        stomachLevel = 0;
        stomachSlider = stomachUI.GetComponent<Slider>();
        stomachBar = stomachUI.GetComponent<RectTransform>();
        sBarDefaultPos = stomachBar.position;
        sBarDefaultSize = stomachBar.sizeDelta;
        stomachSlider.value = stomachLevel;
        stomachSlider.maxValue = stomachSize;
        hitPoints = maxHealth;
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
    //     currentSize = 1;
    //     maxHealth = 3;
    //     hitPoints = maxHealth;
    //     stomachSize = 10;
    //     stomachLevel = 0;
        transform.localScale = new Vector3(0.125f,0.125f,0.125f);
    //     mainCamera.transform.localPosition = new Vector3 (0, 1.25f, -2.125f);
    //     SendMessageUpwards("ReclampRange", SendMessageOptions.RequireReceiver);
    }

    void OnDisable()
    {
        if (stomachBar == null) { return; }
        animator.SetBool("isDead", false);
        isInvincible = false;
        currentSize = 1;
        maxHealth = 3;
        hitPoints = maxHealth;
        stomachSize = 10;
        stomachLevel = 0;        
        stomachBar.position = sBarDefaultPos;
        stomachBar.sizeDelta = sBarDefaultSize;
        FoodDisplay();        
        transform.localScale = new Vector3(0.125f,0.125f,0.125f);
        mainCamera.transform.localPosition = new Vector3 (0, 1.25f, -2.125f);
        SendMessageUpwards("ReclampRange", SendMessageOptions.DontRequireReceiver);
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
        animator.SetTrigger("tookDamage");
        if (hitPoints <= 0)
        {
            animator.SetBool("isDead", true);
            isInvincible = true;
            Debug.Log("You Died");

            //TODO PlayerDeath method "You died etc. etc."
            //TODO make a life depletion method
            Invoke("BecomeGhost", 2f);
            return;
        }
        //TODO Play a sound
        isInvincible = true;
        Invoke("StopInvincibility", 1.5f);
    }

    void StopInvincibility()
    {
        isInvincible = false;
    }

    void BecomeGhost()
    {
        transform.parent.position = new Vector3(0, 300, 0);
        dungeonPosition.position = new Vector3 (0,0,0);
        playerGhost.gameObject.SetActive(true);
        gameObject.SetActive(false);
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
            stomachBar.localPosition += new Vector3 (52.5f, 0, 0);
            stomachBar.sizeDelta += new Vector2 (105f, 0);
            stomachLevel = 0;
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
    
    void HealthDisplay()
    {
        if (hitPoints < 1)
        {
            heart0.SetActive(false);
        }
        if (hitPoints < 2)
        {
            heart1.SetActive(false);
        }
        if (hitPoints < 3)
        {
            heart2.SetActive(false);
        }
        if (hitPoints < 4)
        {
            heart3.SetActive(false);
        }
        if (hitPoints < 5)
        {
            heart4.SetActive(false);
        }
        if (hitPoints < 6)
        {
            heart5.SetActive(false);
        }
        if (hitPoints < 7)
        {
            heart6.SetActive(false);
        }

        if (hitPoints >= 1)
        {
            heart0.SetActive(true);
        }
        if (hitPoints >= 2)
        {
            heart1.SetActive(true);
        }
        if (hitPoints >= 3)
        {
            heart2.SetActive(true);
        }
        if (hitPoints >= 4)
        {
            heart3.SetActive(true);
        }
        if (hitPoints >= 5)
        {
            heart4.SetActive(true);
        }
        if (hitPoints >= 6)
        {
            heart5.SetActive(true);
        }
        if (hitPoints >= 7)
        {
            heart6.SetActive(true);
        }
    }
    
    void FoodDisplay()
    {
        stomachSlider.value = stomachLevel;
        stomachSlider.maxValue = stomachSize;
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
        HealthDisplay();
        if (hitPoints >= 1)
        {
            FoodDisplay();
        }
    }
}
