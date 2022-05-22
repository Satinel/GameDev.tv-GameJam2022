using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] float horizontalDirection = -62;
    [SerializeField] float verticalDirection = 0;
    [SerializeField] Transform dungeon;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // FindObjectOfType<PlayerMovement>().enabled = false;
            dungeon.Translate(horizontalDirection,0,verticalDirection);
            Transform playerParent = other.transform.parent;
            Debug.Log(playerParent.name);
            playerParent.Translate(horizontalDirection,0,verticalDirection);
            // FindObjectOfType<PlayerMovement>().enabled = true;
            // other.transform.Translate(-25,0,0, Space.World);
        }
    }
}
