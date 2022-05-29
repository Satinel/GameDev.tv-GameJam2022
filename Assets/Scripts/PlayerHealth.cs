using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] int hitPoints;
    [SerializeField] int stomachSize = 10; // How much food it takes to fill your stomach
    [SerializeField] int stomachLevel; // How much food has been eaten
    [SerializeField] int requirementIncrease = 5; // How much the next stomach size increases by
    [SerializeField] int currentSize = 1; // The player's size level
    
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
    [SerializeField] TMP_Text playerSizeText;
    [SerializeField] Canvas deathCanvas;
    [SerializeField] TMP_Text deathTextSub;
    [SerializeField] GameObject ratCorpse;
    [SerializeField] AudioClip hurtSFX;
    AudioSource audioSource;
    Animator animator;
    Slider stomachSlider;
    RectTransform stomachBar;
    Vector3 sBarDefaultPos;
    Vector2 sBarDefaultSize;
    bool isSquished = false;
    bool isInvincible;
    bool isBigger;
    
    void Start()
    {
        stomachLevel = 0;
        stomachSlider = stomachUI.GetComponent<Slider>();
        stomachBar = stomachUI.GetComponent<RectTransform>();
        sBarDefaultPos = stomachBar.position;
        sBarDefaultSize = stomachBar.sizeDelta;
        stomachSlider.value = stomachLevel;
        stomachSlider.maxValue = stomachSize;
        hitPoints = maxHealth-1;
        ChangePlayerSizeText();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        playerGhost.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        transform.localScale = new Vector3(0.125f,0.125f,0.125f);
        ChangePlayerSizeText();
    }

    void OnDisable()
    {
        if (stomachBar == null) { return; }
        if (playerSizeText == null) { return; }
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
        playerSizeText.SetText("Ghost");
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
            CreateCorpse();
            Debug.Log("You Died");
            Invoke("PlayerDeathProcess", 0.5f);
            //TODO make a life depletion method
            return;
        }
        audioSource.PlayOneShot(hurtSFX);
        isInvincible = true;
        Invoke("StopInvincibility", 1.5f);
    }

    void CreateCorpse()
    {
        //NOTE if we get to make a boss fight this will likely need addressing
        if (currentSize == 1)
        {
            ratCorpse.transform.localScale = new Vector3 (0.125f, 0.125f, 0.125f);
        }
        if (currentSize == 2)
        {
            ratCorpse.transform.localScale =  new Vector3 (0.125f, 0.125f, 0.125f) * 2;
        }
        if (currentSize == 3)
        {
            ratCorpse.transform.localScale =  new Vector3 (0.5f, 0.5f, 0.5f);
        }
        if (currentSize == 4)
        {
            ratCorpse.transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f) * 2;
        }
        if (currentSize == 5)
        {
            ratCorpse.transform.localScale = new Vector3 (2f, 2f, 2f);
        
        }
        Instantiate(ratCorpse, transform.position, transform.rotation, dungeonPosition);
    }

    void PlayerDeathProcess()
    {
        deathCanvas.enabled = true;
        Invoke("SubtitleDelay", 0.5f);
        Invoke("BecomeGhost", 2.5f);
    }

    void SubtitleDelay()
    {
        deathTextSub.enabled = true;
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
        deathTextSub.enabled = false;
        deathCanvas.enabled = false;
        gameObject.SetActive(false);
    }


    public void GainFood(int foodValue)
    {
        stomachLevel += foodValue;
    }

    IEnumerator IncreaseSize()
    {
        if (currentSize < 5)
        {
            currentSize++;
            stomachSize += currentSize * requirementIncrease;
            SendMessageUpwards("ReclampRange", SendMessageOptions.RequireReceiver);
            maxHealth++;
            hitPoints++;
            
            isInvincible = true;
            isBigger = false;
            for (float i = 0; i < 11; i += 1)
            {
                if (!isBigger)
                {
                    //TODO play SFX at decreased pitch
                    transform.localScale *= 2;
                    isBigger = true;
                }
                else
                {
                    //TODO play SFX at increased pitch
                    transform.localScale *= 0.5f;
                    isBigger = false;
                }
                yield return new WaitForSeconds(0.1f);

            }
            isInvincible = false;

            mainCamera.transform.localPosition *= 2; //mainCamera.transform.position * 2;
            stomachBar.localPosition += new Vector3 (52.5f, 0, 0);
            stomachBar.sizeDelta += new Vector2 (105f, 0);
            stomachLevel = 0;
            ChangePlayerSizeText();
        }
    }

    void ChangePlayerSizeText()
    {
        if (currentSize == 1)
        {
            playerSizeText.SetText("Baby Rat");
        }
        if (currentSize == 2)
        {
            playerSizeText.SetText("Young Rat");
        }
        if (currentSize == 3)
        {
            playerSizeText.SetText("Adult Rat");
        }
        if (currentSize == 4)
        {
            playerSizeText.SetText("Giant Rat");
        }
        if (currentSize == 5)
        {
            playerSizeText.SetText("Dire Rat");
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
        if (currentSize >= 5)
        {
            stomachSlider.value = stomachSlider.maxValue;
            return;
        }
        stomachSlider.value = stomachLevel;
        stomachSlider.maxValue = stomachSize;
    }

    void Update()
    {
        if (stomachLevel >= stomachSize && !isSquished)
        {
            IncreaseSize();
        }
        HealthDisplay();
        if (hitPoints >= 1)
        {
            FoodDisplay();
        }

        //TODO DELETE THESE TWO
        if (Input.GetKeyDown(KeyCode.L))
        {
            IncreaseSize();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CreateCorpse();
        }
    }


}
