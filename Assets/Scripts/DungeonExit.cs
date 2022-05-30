using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonExit : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victoryMusic;
    [SerializeField] Canvas victoryCanvas;
    [SerializeField] PlayerMovement playerMovement;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(playerMovement.GameComplete == true)
            {
                return;
            }
            playerMovement.GetComponent<PlayerMovement>().GameComplete = true;
            Time.timeScale = 0;
            audioSource.Stop();
            audioSource.PlayOneShot(victoryMusic);
            victoryCanvas.enabled = true;
            Debug.Log("VICTORY!");
        }
    }
    
}
