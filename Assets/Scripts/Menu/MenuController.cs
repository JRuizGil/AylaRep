using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Player;
    public GameObject Opciones;
    public GameObject MenuP;
    public GameObject MenuPause;
    // M�todo para salir del juego
    void Start()
    {
        MenuP.SetActive(true);
        Player.SetActive(false);
        Opciones.SetActive(false);
        MenuPause.SetActive(false);
    }
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego..."); // Mensaje en la consola para verificar que funciona
        Application.Quit(); // Cierra la aplicaci�n

#if UNITY_EDITOR
        // Si est�s en el editor, detiene la ejecuci�n del juego
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void ResumeGame()
    {
        Menu.SetActive(false);
        Player.SetActive(true);
        MenuPause.SetActive(false);
    }
    public void OptionsGame()
    {
        Opciones.SetActive(true);
        MenuP.SetActive(false);
    }
    public void OptionsVolver()
    {
        MenuP.SetActive(true);
        Opciones.SetActive(false);
    }
}
