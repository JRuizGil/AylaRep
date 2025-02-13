using System.Collections.Generic;
using UnityEngine;

public class Liana : Bullet
{
    private int contadorParticulas = 0;
    public int limiteParticulas = 2;

    // Lista para almacenar las part�culas espec�ficas
    private List<ParticleSystem> particulasObjetivo = new List<ParticleSystem>();

    private void Start()
    {
        // Busca y registra las part�culas espec�ficas ya instanciadas
        GameObject[] antorchas = GameObject.FindGameObjectsWithTag("Antorcha");
        foreach (GameObject antorcha in antorchas)
        {
            ParticleSystem particula = antorcha.GetComponent<ParticleSystem>();

            if (particula != null && !particula.isPlaying)
            {
                // Solo a�ade part�culas instanciadas pero no activadas
                particulasObjetivo.Add(particula);
            }
        }

        Debug.Log("Part�culas espec�ficas registradas: " + particulasObjetivo.Count);
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
        // Verifica solo las part�culas espec�ficas registradas
        foreach (ParticleSystem particula in particulasObjetivo)
        {
            if (particula.isPlaying)
            {
                contadorParticulas++;
                Debug.Log("Part�culas espec�ficas activadas: " + contadorParticulas);

                // Elimina la part�cula activada de la lista para no contarla de nuevo
                particulasObjetivo.Remove(particula);
                break; // Sal de la iteraci�n despu�s de contar una
            }
        }

        // Destruye el objeto si se alcanz� el l�mite
        if (contadorParticulas >= limiteParticulas)
        {
            Destroy(gameObject);
            Debug.Log("�Objeto destruido por activaci�n de part�culas espec�ficas!");
        }
    }
}
