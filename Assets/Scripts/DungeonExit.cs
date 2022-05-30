using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonExit : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victoryMusic;
    [SerializeField] Canvas victoryCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            audioSource.Stop();
            audioSource.PlayOneShot(victoryMusic);
            victoryCanvas.enabled = true;
            Debug.Log("VICTORY!");
        }
    }
    
}
