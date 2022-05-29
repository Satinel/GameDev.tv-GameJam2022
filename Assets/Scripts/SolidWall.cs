using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidWall : MonoBehaviour
{

    Vector3 contactPosition;

    void OnTriggerEnter(Collider other)
    {
        contactPosition = other.transform.parent.position;
    }

    void OnTriggerExit(Collider other)
    {
        other.transform.parent.position = contactPosition;
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
