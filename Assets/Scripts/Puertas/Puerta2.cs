using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liana : MonoBehaviour
{
    private int antorchasEncendidas = 0;
    public GameObject objetoParaDesactivar;  // Arrastra aquí el GameObject que quieres desactivar

    private void OnEnable()
    {
        Bullet.AntorchaEncendida += OnAntorchaEncendida;
    }

    private void OnDisable()
    {
        Bullet.AntorchaEncendida -= OnAntorchaEncendida;
    }

    private void OnAntorchaEncendida()
    {
        antorchasEncendidas++;
        Debug.Log("Antorchas encendidas: " + antorchasEncendidas);

        // Si se han encendido 2 antorchas, desactiva el GameObject
        if (antorchasEncendidas >= 5)
        {
            if (objetoParaDesactivar != null)
            {
                objetoParaDesactivar.SetActive(false);
                Debug.Log("Objeto desactivado.");
            }
        }
    }
}
