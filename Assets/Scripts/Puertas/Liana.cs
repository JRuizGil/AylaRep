using System.Collections.Generic;
using UnityEngine;

public class Liana : Bullet
{
    private int contadorParticulas = 0;
    public int limiteParticulas = 2;

    // Lista para almacenar las partículas específicas
    private List<ParticleSystem> particulasObjetivo = new List<ParticleSystem>();

    private void Start()
    {
        // Busca y registra las partículas específicas ya instanciadas
        GameObject[] antorchas = GameObject.FindGameObjectsWithTag("Antorcha");
        foreach (GameObject antorcha in antorchas)
        {
            ParticleSystem particula = antorcha.GetComponent<ParticleSystem>();

            if (particula != null && !particula.isPlaying)
            {
                // Solo añade partículas instanciadas pero no activadas
                particulasObjetivo.Add(particula);
            }
        }

        Debug.Log("Partículas específicas registradas: " + particulasObjetivo.Count);
    }

    private void OnEnable()
    {
        // Suscribirse al evento
        Bullet.OnParticulaActivada += ContarParticulas;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento
        Bullet.OnParticulaActivada -= ContarParticulas;
    }

    private void ContarParticulas()
    {
        // Verifica solo las partículas específicas registradas
        foreach (ParticleSystem particula in particulasObjetivo)
        {
            if (particula.isPlaying)
            {
                contadorParticulas++;
                Debug.Log("Partículas específicas activadas: " + contadorParticulas);

                // Elimina la partícula activada de la lista para no contarla de nuevo
                particulasObjetivo.Remove(particula);
                break; // Sal de la iteración después de contar una
            }
        }

        // Destruye el objeto si se alcanzó el límite
        if (contadorParticulas >= limiteParticulas)
        {
            Destroy(gameObject);
            Debug.Log("¡Objeto destruido por activación de partículas específicas!");
        }
    }
}
