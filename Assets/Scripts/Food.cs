using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] int maxFoodPoints = 3;
    [SerializeField] int foodPoints;
    [SerializeField] int foodValue = 1;
    EnemyBehaviour enemyBehaviour;

    void Start()
    {
        enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
    }

    void OnEnable()
    {
        foodPoints = maxFoodPoints;
    }

    public int getAte(int damage)
    {
        foodPoints -= damage;
        if(foodPoints <= 0)
        {
            enemyBehaviour.Respawn();
            gameObject.SetActive(false);
        }
        return foodValue;
    }
}
