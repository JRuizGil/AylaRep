using UnityEngine;
using UnityEngine.UI;

public class MostrarTextoTrigger : MonoBehaviour
{
    public GameObject fireTutorial; // Arrastra el objeto de texto en el Inspector

    void Start()
    {
        fireTutorial.SetActive(false); // Oculta el texto al inicio
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el personaje entra en la zona
        {
            fireTutorial.SetActive(true); // Muestra el texto
        }
    }
}
