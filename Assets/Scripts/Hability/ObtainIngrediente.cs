using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtainIngrediente : MonoBehaviour
{
    private int ingredientes = 0;
    public bool isInsideTrigger;
    public GameObject Mariposa;
    public GameObject Counterobj;
    public Text Counter;
    // Start is called before the first frame update
    void Start()
    {
        Counterobj.SetActive(false);
        isInsideTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTrigger)
        {
            Mariposa.SetActive(false);
        }
        Counter.text = ingredientes.ToString();

    }
    void OnTriggerEnter2D(Collider2D bola)
    {
        if (bola.CompareTag("Player"))
        {
            isInsideTrigger = true;
            StartCoroutine(ActivarTemporalmente());
        }

    }
    private IEnumerator ActivarTemporalmente()
    {
        Counterobj.SetActive(true);
        yield return new WaitForSeconds(5);
        Counterobj.SetActive(false);
    }
}
