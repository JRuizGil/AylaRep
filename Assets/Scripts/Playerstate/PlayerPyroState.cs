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
    private Vector2 shootDirection; // Dirección hacia donde disparará
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
        if (!Input.GetMouseButtonDown(0) || firePoint == null || bulletPrefab == null) return;

        float direction = Mathf.Sign(Player.transform.localScale.x); // 1 para derecha, -1 para izquierda
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * direction * bulletSpeed;
        bullet.transform.localScale = new Vector3(direction, 1, 1); // Ajusta la dirección visual

        Debug.Log($"Disparo en dirección: {(direction > 0 ? "derecha" : "izquierda")}");
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
