using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonEntrance : MonoBehaviour
{
    PlayerMovement playerMovement;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMovement = other.GetComponentInParent<PlayerMovement>();
            if (!playerMovement.TutorialDone)
            {
                other.transform.parent.localPosition = new Vector3 (0,250,-12);
            }
            else
            {
                other.transform.parent.localPosition = new Vector3 (0,0,0);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
