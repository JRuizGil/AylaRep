using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta3 : MonoBehaviour
{
    private int antorchasEncendidas = 0;
    public GameObject objetoParaDesactivar;  
    public Text Counter;
    public GameObject Counterobj;

    public void Awake()
    {
        Counterobj.SetActive(false);
    }
    public void Update()
    {
        Counter.text = antorchasEncendidas.ToString();
    }
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
        StartCoroutine(ActivarTemporalmente());
        Debug.Log("Antorchas encendidas: " + antorchasEncendidas);

        // Si se han encendido 2 antorchas, desactiva el GameObject
        if (antorchasEncendidas >= 12)
        {
            if (objetoParaDesactivar != null)
            {
                objetoParaDesactivar.SetActive(false);
                Counterobj.SetActive(false);
                Debug.Log("Objeto desactivado.");

            }
        }
    }
    private IEnumerator ActivarTemporalmente()
    {
        Counterobj.SetActive(true);   
        yield return new WaitForSeconds(5);  
        Counterobj.SetActive(false);  
    }
}
