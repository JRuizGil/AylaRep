using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f; // Tiempo de vida de la bala

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruye la bala después de cierto tiempo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Liana")) // Verifica si el objeto tiene el tag "Liana"
        {
            Destroy(collision.gameObject); // Destruye la liana
            Destroy(gameObject); // Destruye la bala
            Debug.Log("Bala impactó con: " + collision.gameObject.name);
        }
    }
}
