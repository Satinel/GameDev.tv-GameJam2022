using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int moveSpeed = 10;
    // [SerializeField] float rotationSpeed = 0.15f;
    [SerializeField] float xRange = 25;
    [SerializeField] float zRange = 10;
    float xThrow;
    float zThrow;

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
        ProcessTranslation();
    }

}
