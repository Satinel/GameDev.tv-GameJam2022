using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    Canvas canvas;
    bool isPaused;

    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Cursor.visible = true;
            canvas.enabled = false;
            AudioListener.pause = false;
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 0;
            canvas.enabled = true;
            AudioListener.pause = true;
            isPaused = true;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseGame();
        }
    }
}
