using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatTutorial : MonoBehaviour
{
    int foodPoints = 4;
    int foodValue = 3;
    
    public int getAte(int damage)
    {
        foodPoints -= damage;
        if(foodPoints <= 0)
        {
            Destroy(gameObject);
        }
        return foodValue;
    }
}
