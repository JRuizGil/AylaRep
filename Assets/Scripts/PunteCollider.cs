using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunteCollider : MonoBehaviour
{
    [Header("GameObjects to Deactivate")]
    public GameObject gameObject1; // Primer GameObject a desactivar
    public GameObject gameObject2; // Segundo GameObject a desactivar
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
        // Verifica si el objeto que entró tiene el tag "Demolition"
        if (other.CompareTag("Demolition"))
        {
            // Desactiva los GameObjects asignados
            if (gameObject1 != null)
            {
                gameObject1.SetActive(false);
            }

            if (gameObject2 != null)
            {
                gameObject2.SetActive(false);
            }

            // Opcional: Mensaje en la consola
            Debug.Log("GameObjects desactivados porque un objeto con el tag 'Demolition' entró en el trigger.");
        }
    }
}

