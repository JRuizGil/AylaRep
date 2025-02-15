using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Player;
    public GameObject Opciones;
    public GameObject MenuPause;

    private bool _isPaused;
    private bool _MenuPrincipal;
    private bool _isOnMenuAjustes;


    // Método para salir del juego
    void Start()
    {
        _MenuPrincipal = true;
        _isPaused = true;
        _isOnMenuAjustes = false;
        Menu.SetActive(true);
        Player.SetActive(false);
        Opciones.SetActive(false);
        MenuPause.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                if (_isOnMenuAjustes)
                {
                    OptionsVolver();
                }
                else
                {
                    ResumeGame();
                }
            }
            else
            {
                PauseGame();
            }
        }        
               
    }

    public void PauseGame()
    {
        _isPaused = true;
        MenuPause.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ResumeGame()
    {
        Player.SetActive(true);
        MenuPause.SetActive(false);
        Menu.SetActive(false);
        Opciones.SetActive(false);

        _isPaused = false;

        Time.timeScale = 1f;
         
    }
    public void QuitToMainMenu()
    {        
        MenuPause.SetActive(false);
        Menu.SetActive(true);
        _MenuPrincipal = true;
    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego..."); 
        Application.Quit(); 

#if UNITY_EDITOR        
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }      
    public void AjustesGame()
    {        
        _MenuPrincipal = true;
        _isOnMenuAjustes = true;
        Opciones.SetActive(true);
        Menu.SetActive(false);
        MenuPause.SetActive(false);

    }
    public void AjustesPauseGame()
    {
        _isOnMenuAjustes = true;
        _MenuPrincipal = false;
        Opciones.SetActive(true);
        Menu.SetActive(false);
        MenuPause.SetActive(false);
    }
    public void OptionsVolver()
    {
        if (_MenuPrincipal)
        {
            Menu.SetActive(true);
            Opciones.SetActive(false);
            _isOnMenuAjustes = false;
        }
        else
        {
            MenuPause.SetActive(true) ;
            Opciones.SetActive(false);
            _isOnMenuAjustes = false;
        }


    }
}
