using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBiteAttack : MonoBehaviour
{
    int damage = 1;
    int playerSize = 10;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<PlayerHealth>();
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
            playerHealth.IncreaseHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
