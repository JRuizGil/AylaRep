using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f; // Tiempo de vida de la bala  
    public static event System.Action AntorchaEncendida;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Liana"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Debug.Log("Bala impactó con: " + collision.gameObject.name);
        }

        // Comprobar si el objeto con el que colisionamos tiene la etiqueta "Antorcha"
        if (collision.gameObject.CompareTag("Antorcha"))
        {
            Animator animator = collision.gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetTrigger("Encender");                
                AntorchaEncendida.Invoke();
            }
        }
    }
    
}
