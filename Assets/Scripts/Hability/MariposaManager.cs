using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MariposaManager : MonoBehaviour
{
    private int ingredientes;
    public GameObject[] Mariposas;
    public GameObject Counterobj;
    public Text Counter;
    private Dictionary<GameObject, (SpriteRenderer, Collider2D)> mariposaComponents;

    void Start()
    {
        mariposaComponents = new Dictionary<GameObject, (SpriteRenderer, Collider2D)>();

        foreach (GameObject mariposa in Mariposas)
        {
            SpriteRenderer renderer = mariposa.GetComponent<SpriteRenderer>();
            Collider2D collider = mariposa.GetComponent<Collider2D>();
            mariposaComponents[mariposa] = (renderer, collider);
            renderer.enabled = true;
            collider.enabled = true;
        }

        Counterobj.SetActive(false);
        ingredientes = 0;
    }

    void Update()
    {
        Counter.text = ingredientes.ToString();
    }

    public void ObtenerIngrediente(GameObject mariposa)
    {
        if (mariposaComponents.ContainsKey(mariposa))
        {
            ingredientes++;
            StartCoroutine(ActivarTemporalmente());
            mariposaComponents[mariposa].Item1.enabled = false;
            mariposaComponents[mariposa].Item2.enabled = false;
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
