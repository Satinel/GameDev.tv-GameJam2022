using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBiteAttack : MonoBehaviour
{
    int damage = 1;
    int playerSize = 10;
    PlayerHealth playerHealth;

    void Start()
    {
        // Transform[] transforms = GetComponentsInParent<Transform>();
        // foreach (Transform transform in transforms)
        // {
        //     Debug.Log(transform.gameObject.name);
        // }
        playerHealth = GetComponentInParent<PlayerHealth>();
        Debug.Log(playerHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().getHit(damage * playerSize);
            Debug.Log("I bit " + other.gameObject.name + " for " + damage*playerSize);
            playerHealth.IncreaseHealth();
        }

        if (other.gameObject.tag == "Food")
        {
            //TODO make a script for foods to get eaten
            //other.GetComponent<Food>().getAte(damage);
            Debug.Log("I ate " + other.gameObject.name);
            playerHealth.IncreaseHealth();
        }
    }

    void Update()
    {
        
    }
}
