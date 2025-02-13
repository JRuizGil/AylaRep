using UnityEngine;

public class Treescene : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;  // Referencia al SpriteRenderer del objeto
    private bool isInside = false;          // Bandera para saber si el Player está adentro

    private void Start()
    {
        // Asegúrate de que el SpriteRenderer esté asignado
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        // Si está dentro, desactiva el SpriteRenderer
        if (isInside)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            // Si no está dentro, activa el SpriteRenderer
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInside = false;
        }
    }
}
