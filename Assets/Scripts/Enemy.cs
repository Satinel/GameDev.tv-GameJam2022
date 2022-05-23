using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;

    void Start()
    {
        
    }

    public void getHit(int damage)
    {
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
