using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwipeAttack : MonoBehaviour
{
    int damage = 1;
    int playerSize = 10;

    // void OnEnable()
    // {
    //     Transform currentSize = GetComponentInParent<Transform>();
    //     playerSize = currentSize.localScale.z;
    //     Debug.Log("player size: " + playerSize);
    //     Debug.Log("current size: " + currentSize);
    // }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().getHit(damage * playerSize);
            Debug.Log("I hit " + other.gameObject.name + " for " + damage*playerSize);
        }
    }

}
