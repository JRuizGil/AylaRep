using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;  // Asigna el menú de pausa en el Inspector
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;  // Pausa el tiempo
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;  // Reanuda el tiempo
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;  // Asegura que el tiempo vuelva a la normalidad
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Cambia "MainMenu" por el nombre de tu escena de menú
    }
}