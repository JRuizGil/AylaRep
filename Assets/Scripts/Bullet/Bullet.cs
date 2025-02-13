using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f; // Tiempo de vida de la bala
    private bool particulaActiva = false;
    public static event System.Action OnParticulaActivada;


    void Start()
    {
        Destroy(gameObject, lifeTime);         
    }
    private void Awake()
    {
        
    }
    public void Update()
    {
        if (particulaActiva)
        {            
            ParticleSystem particula = GameObject.FindGameObjectWithTag("Antorcha").GetComponent<ParticleSystem>();

            if (particula != null && !particula.IsAlive())
            {                
                Destroy(gameObject);
            }
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Liana")) 
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
            Debug.Log("Bala impactó con: " + collision.gameObject.name);
        }
        if (collision.CompareTag("Antorcha"))
        {
            ParticleSystem particula = collision.gameObject.GetComponent<ParticleSystem>();

            if (particula != null) 
            {
                if (!particula.isPlaying) 
                {
                    particula.Play();                                        
                    Bullet.OnParticulaActivada?.Invoke();
                }
            }
        }
    }
}
