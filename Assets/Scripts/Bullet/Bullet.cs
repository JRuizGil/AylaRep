using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f; // Tiempo de vida de la bala

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruye la bala despu�s de cierto tiempo
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bala impact� con: " + collision.name);

        Destroy(gameObject);
    }
}
