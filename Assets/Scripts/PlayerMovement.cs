using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int moveSpeed = 10;
    [SerializeField] int rotationSpeed = 200;
    
    
    void Start()
    {
        
    }

    void MovePlayer() //TODO maybe find some way to do this that actually works thanks
    {
        float moveLeftRight = Input.GetAxis("Horizontal");
        float moveUpDown = Input.GetAxis("Vertical");
        Vector3 movePlayer = new Vector3(moveLeftRight, 0, moveUpDown);
        transform.rotation = Quaternion.LookRotation(movePlayer);
        transform.Translate(movePlayer * Time.deltaTime * moveSpeed, Space.World);
        
    }

    void RotatePlayer()
    {
        float playerRotate = Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed;
        transform.Rotate(0,playerRotate,0);
    }
    
    void Update()
    {
        MovePlayer();
        // RotatePlayer();
    }
}
