using UnityEngine;

public class DemolitionSound : MonoBehaviour
{
    public AudioSource audioSource; 
    public float minVolume = 0.2f;  
    public float maxVolume = 0.5f;  
    public float maxSpeed = 5f;     

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        float speedX = Mathf.Abs(rb.velocity.x); 
        float normalizedSpeed = Mathf.Clamp01(speedX / maxSpeed); 
        audioSource.volume = Mathf.Lerp(minVolume, maxVolume, normalizedSpeed); 
    }
}
