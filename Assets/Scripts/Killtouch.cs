using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killtouch : MonoBehaviour
{
    public Transform respawnPoint;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.CompareTag("Player")) 
        {
            other.transform.position = respawnPoint.position;
        }
    }
}

