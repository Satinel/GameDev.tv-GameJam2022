using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    //https://answers.unity.com/questions/803365/make-the-player-face-his-movement-direction.html
    [SerializeField] float rotationSpeed = 0.15f;
    float xThrow;
    float zThrow;
    void RotatePlayer()
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
    }
    
    void Update()
    {
        RotatePlayer();
    }
}
