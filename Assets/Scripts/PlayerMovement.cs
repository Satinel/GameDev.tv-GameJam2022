using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int moveSpeed = 10;
    // [SerializeField] float rotationSpeed = 0.15f;
    [SerializeField] float xRange = 26.7f;
    [SerializeField] float zRange = 15.25f;
    float xThrow;
    float zThrow;

    public bool isAttacking;
    public bool TutorialDone;

    [SerializeField] PlayerHealth playerHealth;

    // void Start()
    // {
    //     playerHealth = GetComponentInChildren<PlayerHealth>();
    // }

    void OnEnable()
    {
        playerHealth = GetComponentInChildren<PlayerHealth>();
        ReclampRange();
    }

    void ReclampRange()
    {
        int size = playerHealth.GetCurrentSize();
        if (size == 1)
        {
            xRange = 26.7f;
            zRange = 15.25f;
            moveSpeed = 5;
        }
        if (size == 2)
        {
            xRange = 26.4f;
            zRange = 14.9f;
            moveSpeed = 7;
        }
        if (size == 3)
        {
            xRange = 25.75f;
            zRange = 14.3f;
            moveSpeed = 10;
        }
        if (size == 4)
        {
            xRange = 25.5f;
            zRange = 13.25f;
            moveSpeed = 14;
        }
        if (size == 5)
        {
            xRange = 21.8f;
            zRange = 10.25f;
            moveSpeed = 19;
        }
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        zThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float zOffset = zThrow * Time.deltaTime * moveSpeed;
        float rawZPos = transform.localPosition.z + zOffset;
        float clampedYPos = Mathf.Clamp(rawZPos, -zRange, zRange);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedYPos);
    }
    
    void Update()
    {
        if (!isAttacking)
        {
            ProcessTranslation();
        }
    }

}
