using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int maxFoodPoints = 3;
    [SerializeField] int foodPoints;
    EnemyBehaviour enemyBehaviour;

    void Start()
    {
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
    }

    void OnEnable()
    {
        foodPoints = maxFoodPoints;
    }

    public void getAte(int damage)
    {
        foodPoints -= damage;
        if(foodPoints <= 0)
        {
            enemyBehaviour.Respawn();
            gameObject.SetActive(false);
        }
    }
}
