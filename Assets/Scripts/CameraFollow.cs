using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Referencia al objeto que la c�mara debe seguir (generalmente el jugador)
    public Transform player;

    // Offset para mantener la c�mara a una distancia espec�fica del jugador
    public Vector3 offset;

    // Velocidad de suavizado para que el movimiento sea m�s fluido
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posici�n deseada
            Vector3 desiredPosition = player.position + offset;

            // Suaviza el movimiento de la c�mara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establece la nueva posici�n de la c�mara
            transform.position = smoothedPosition;

            // Opcional: Asegura que la c�mara siempre mire al jugador
            // transform.LookAt(player);
        }
    }
}

