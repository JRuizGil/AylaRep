using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Referencia al objeto que la cámara debe seguir (generalmente el jugador)
    public Transform player;

    // Offset para mantener la cámara a una distancia específica del jugador
    public Vector3 offset;

    // Velocidad de suavizado para que el movimiento sea más fluido
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (player != null)
        {
            // Calcula la posición deseada
            Vector3 desiredPosition = player.position + offset;

            // Suaviza el movimiento de la cámara
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Establece la nueva posición de la cámara
            transform.position = smoothedPosition;

            // Opcional: Asegura que la cámara siempre mire al jugador
            // transform.LookAt(player);
        }
    }
}

