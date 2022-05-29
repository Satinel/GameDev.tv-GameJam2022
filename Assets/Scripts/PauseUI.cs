using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseUI : MonoBehaviour
{
    [SerializeField] GameObject pauseFirstButton;
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
            EventSystem.current.SetSelectedGameObject(null);
            isPaused = false;
        }
        else
        {
            Cursor.visible = false;
            Time.timeScale = 0;
            AudioListener.pause = true;
            canvas.enabled = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
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
