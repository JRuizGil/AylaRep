using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Player;
    // Método para salir del juego
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego..."); // Mensaje en la consola para verificar que funciona
        Application.Quit(); // Cierra la aplicación

#if UNITY_EDITOR
        // Si estás en el editor, detiene la ejecución del juego
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void ResumeGame()
    {
        Menu.SetActive(false);
        Player.SetActive(true);
    }
}
