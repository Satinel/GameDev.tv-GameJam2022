using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KumoKey : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CollectKeys>().DefeatedKumoko = true;
            Debug.Log("You defeated Kumoko!");
        }

    }
}
