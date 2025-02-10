using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainHability : MonoBehaviour
{
    public bool isInsideTrigger;
    public GameObject Bola;

    // Start is called before the first frame update
    void Start()
    {
        isInsideTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideTrigger)
        {
            Bola.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D bola)
    {
        if (bola.CompareTag("Player"))
        {
            isInsideTrigger = true;
        }

    }    
}
