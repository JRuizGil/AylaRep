using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerPyroState : PlayerBaseState
{
    public GameObject Paloobj;
    public GameObject Player;
    public GameObject bulletPrefab; // El prefab de la bala
    public Transform firePoint; // Punto desde donde se dispara la bala
    public float bulletSpeed = 20f; // Velocidad de la bala
    private Vector2 shootDirection; // Direcci�n hacia donde disparar�
    private Rigidbody2D rb;
    
    public override void EnterState(PlayerStateManager player)
    {
        Pyro = true;
        Bola = true;
        Palo = false;
        Puente = false;
        Debug.Log("Helo pyro state");
    }
    public override void UpdateState(PlayerStateManager player)
    {
        
        PyroHab();
        if (Palo && Puente== false)
        {
            Puente = true;
            player.SwitchState(player.PuenteState);
        }

    }
    public void PyroHab()
    {
        if (Input.GetMouseButtonDown(0)) // Clic izquierdo del rat�n
        {
            if (firePoint == null || bulletPrefab == null)
            {
                Debug.LogError("No se puede disparar: firePoint o bulletPrefab no est� asignado.");
                return;
            }

            // Determina la direcci�n del disparo seg�n la escala del jugador
            float direction = Mathf.Sign(Player.transform.localScale.x); // 1 para derecha, -1 para izquierda

            // Instancia la bala
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            // Aplica movimiento a la bala
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = new Vector2(direction * bulletSpeed, 0); // Disparo horizontal
            }

            // Ajusta la rotaci�n de la bala para que apunte hacia la direcci�n correcta
            bullet.transform.localScale = new Vector3(direction * Mathf.Abs(bullet.transform.localScale.x), bullet.transform.localScale.y, bullet.transform.localScale.z);

            Debug.Log("�Disparo realizado en direcci�n: " + (direction > 0 ? "derecha" : "izquierda") + "!");
        }
    }
    public void EarnAbility()
    {
        if (!Paloobj.activeSelf)
        {
            Palo = true;
            Debug.Log("habilidad cogida");
        }
    }
    
}
