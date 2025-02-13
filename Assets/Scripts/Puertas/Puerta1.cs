using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta1 : MonoBehaviour
{
    private int antorchasEncendidas = 0;
    public GameObject objetoParaDesactivar;

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
        if (antorchasEncendidas >= 1)
        {
            if (objetoParaDesactivar != null)
            {
                objetoParaDesactivar.SetActive(false);
                Debug.Log("Objeto desactivado.");
            }
        }
    }
}
