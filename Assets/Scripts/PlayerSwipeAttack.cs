using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwipeAttack : MonoBehaviour
{
    int damage = 1;
    int playerSize;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            int playerSize = playerHealth.GetCurrentSize();
            other.GetComponent<Enemy>().getHit(damage * playerSize * 2);
            Debug.Log("I hit " + other.gameObject.name + " for " + damage*playerSize*2);
        }
    }

}
