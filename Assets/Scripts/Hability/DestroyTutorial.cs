using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class DestroyTutorial : MonoBehaviour
{
    public GameObject fireTutorial; // Texto del tutorial
    public GameObject Liana3; // Objeto que, si se destruye, eliminar� el tutorial

    void Update()
    {
        // Si Liana3 ha sido destruida (es null), tambi�n destruimos el texto
        if (Liana3 == null)
        {
            Destroy(fireTutorial);
        }
    }
}