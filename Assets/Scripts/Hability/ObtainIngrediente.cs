using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtainIngrediente : MonoBehaviour
{
    private int ingredientes;
    public GameObject Mariposa;
    public GameObject Counterobj;
    public Text Counter;
    // Start is called before the first frame update
    void Start()
    {
        Mariposa.SetActive(true);
        Counterobj.SetActive(false);
        ingredientes = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Counterobj.activeSelf)
        {
            Counter.text = ingredientes.ToString();
        }
    }

    void OnTriggerEnter2D(Collider2D bola)
    {
        if (bola.CompareTag("Player"))
        {
            ingredientes++;
            StartCoroutine(ActivarTemporalmente());
            Mariposa.SetActive(false);
        }
    }

    private IEnumerator ActivarTemporalmente()
    {
        Counterobj.SetActive(true);
        Debug.Log("Mostrando contador...");

        yield return new WaitForSeconds(5);

        Counterobj.SetActive(false);
        Debug.Log("Ocultando contador...");
    }


}
