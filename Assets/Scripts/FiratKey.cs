using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiratKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CollectKeys>().DefeatedFireRat = true;
            // Debug.Log("You defeated Dire Fire Rat!");
        }

    }
}
