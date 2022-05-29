using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBiteAttack : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int playerSize;
    [SerializeField] GameObject biteFX;
    PlayerHealth playerHealth;
    PlayerMovement playerMovement;

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
            Instantiate(biteFX, transform.position, Quaternion.identity);
            biteFX.transform.localScale = new Vector3 (playerSize, playerSize, playerSize);
            Debug.Log("I bit " + other.gameObject.name + " for " + damage*playerSize);
            // playerHealth.IncreaseHealth();
        }

        if (other.gameObject.tag == "Food")
        {
            int foodSource = other.GetComponent<Food>().getAte(damage);
            Instantiate(biteFX, transform.position, Quaternion.identity);
            biteFX.transform.localScale = other.transform.localScale;
            Debug.Log("I ate " + other.gameObject.name + " and it was worth " + foodSource);
            playerHealth.IncreaseHealth();
            playerHealth.GainFood(foodSource);
        }

        if (other.gameObject.tag == "PlayerCorpse")
        {
            int foodSource = other.GetComponent<EatTutorial>().getAte(damage);
            Instantiate(biteFX, transform.position, Quaternion.identity);
            biteFX.transform.localScale = other.transform.localScale;
            playerMovement = GetComponentInParent<PlayerMovement>();
            playerMovement.TutorialDone = true;
            playerHealth.IncreaseHealth();
            playerHealth.GainFood(foodSource);
        }
    }

}
