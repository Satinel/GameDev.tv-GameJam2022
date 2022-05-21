using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int moveSpeed = 10;
    [SerializeField] float rotationSpeed = 0.15f;
    float xRange = 29;
    float zRange = 16;
    
    void Start()
    {
        
    }

    //https://answers.unity.com/questions/803365/make-the-player-face-his-movement-direction.html
    void MovePlayer() 
    {
        float moveLeftRight = Input.GetAxis("Horizontal");
        float moveUpDown = Input.GetAxis("Vertical");
        Vector3 movePlayer = new Vector3(moveLeftRight, 0, moveUpDown);
        if (movePlayer != Vector3.zero)
        {
            transform.rotation = 
            Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movePlayer), rotationSpeed);
        }
        transform.Translate(movePlayer * Time.fixedDeltaTime * moveSpeed, Space.World); 
    }

    float xThrow;
    float zThrow;

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        zThrow = Input.GetAxis("Vertical");
        Vector3 lookDirection = new Vector3(xThrow, 0, zThrow);
        if (lookDirection != Vector3.zero)
        {
            transform.rotation = 
            Quaternion.Slerp(transform.rotation, 
                            Quaternion.LookRotation(lookDirection), 
                            rotationSpeed);
        }

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float zOffset = zThrow * Time.deltaTime * moveSpeed;
        float rawZPos = transform.localPosition.z + zOffset;
        float clampedYPos = Mathf.Clamp(rawZPos, -zRange, zRange);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, clampedYPos);
    }
    
    void FixedUpdate()
    {
        // MovePlayer();
        ProcessTranslation();
    }
}
