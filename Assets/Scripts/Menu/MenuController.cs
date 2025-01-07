using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject Menu;
    public GameObject Player;
    // M�todo para salir del juego
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
    }
}
