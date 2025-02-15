using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteCollider : MonoBehaviour
{
    [Header("GameObjects to Deactivate")]
    public GameObject gameObject1; 
    public GameObject gameObject2; 
    public GameObject gameObject3;
    // Start is called before the first frame update
    void Start()
    {
        gameObject1.SetActive(true);
        gameObject2.SetActive(true);
        gameObject3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Demolition"))
        {
            
            if (gameObject1 != null)
            {
                gameObject1.SetActive(false);
            }
            if (gameObject2 != null)
            {
                gameObject2.SetActive(false);
            }
            if (gameObject3 != null)
            {
                gameObject3.SetActive(true);
            }
            
        }
    }
}

