using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBiteAttack : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int playerSize = 10;
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
            other.GetComponent<Enemy>().getHit(damage * playerSize);
            Debug.Log("I bit " + other.gameObject.name + " for " + damage*playerSize);
            // playerHealth.IncreaseHealth();
        }

        if (other.gameObject.tag == "Food")
        {
            int foodSource = other.GetComponent<Food>().getAte(damage);
            Debug.Log("I ate " + other.gameObject.name + " for " + damage + "damage and it was worth" + foodSource);
            playerHealth.IncreaseHealth();
            playerHealth.GainFood(foodSource);
        }
    }

    void Update()
    {
        
    }
}
