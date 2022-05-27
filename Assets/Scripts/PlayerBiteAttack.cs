using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBiteAttack : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int playerSize;
    PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
        Debug.Log(playerHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            int playerSize = playerHealth.GetCurrentSize();
            Debug.Log("Player Size: " + playerSize);
            other.GetComponent<Enemy>().getHit(damage * playerSize);
            Debug.Log("I bit " + other.gameObject.name + " for " + damage*playerSize);
            // playerHealth.IncreaseHealth();
        }

        if (other.gameObject.tag == "Food")
        {
            int foodSource = other.GetComponent<Food>().getAte(damage);
            Debug.Log("I ate " + other.gameObject.name + " and it was worth " + foodSource);
            playerHealth.IncreaseHealth();
            playerHealth.GainFood(foodSource);
        }
    }

    void Update()
    {
        
    }
}
