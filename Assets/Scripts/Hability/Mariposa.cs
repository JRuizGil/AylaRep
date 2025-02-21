using UnityEngine;

public class Mariposa : MonoBehaviour
{
    public MariposaManager manager;

    void OnTriggerEnter2D(Collider2D bola)
    {
        if (bola.CompareTag("Player"))
        {
            manager.ObtenerIngrediente(gameObject);
            Destroy(gameObject);
        }
    }
}