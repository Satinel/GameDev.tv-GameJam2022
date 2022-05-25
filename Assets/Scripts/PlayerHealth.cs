using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    [SerializeField] int hitPoints;

    public void IncreaseHealth()
    {
        if (hitPoints < maxHealth)
        {
            hitPoints++;
        }
    }

    //TODO IncreaseSize()
    
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
