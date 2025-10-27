using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsortKey : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CollectKeys>().DefeatedConsortSlime = true;
            // Debug.Log("You defeated the queen's consort!");
        }

    }
}
