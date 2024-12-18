using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapOpener : MonoBehaviour
{

    public GameObject Player;
    public GameObject Camara1;
    public bool Camaractiv = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entró tiene el tag "Player"
        if (Player != null && Player.GetComponent<Collider2D>() != null)
        {
            Collider2D gameObject1Collider = Player.GetComponent<Collider2D>();
            if (gameObject1Collider.IsTouching(GetComponent<Collider2D>()))
            {
                Debug.Log("GameObject1 está dentro del trigger.");
            }
        }
        if (Player)
        {
            Debug.Log("Player dentro");
            // Desactiva los GameObjects asignados
            if (Input.GetKey(KeyCode.Tab) && Camaractiv==false)
            {
                Debug.Log("Mapa Abierto");
                Camara1.SetActive(true);
                Player.SetActive(false);
                Camaractiv = true;
            }
            if (Input.GetKey(KeyCode.Tab) && Camaractiv)
            {
                Debug.Log("Mapa Cerrado");
                Camara1.SetActive(false);
                Player.SetActive(true);
                Camaractiv = false;
            }


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
