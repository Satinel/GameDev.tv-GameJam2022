using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquishAttack : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] int size = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().DecreaseHealth(damage * size);
            other.GetComponent<PlayerHealth>().SquishThatRat();
            // Debug.Log("I squished " + other.gameObject.name + "!");
        }
    }
}
