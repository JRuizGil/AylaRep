using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public float dashDistance = 5f;
    public float dashCooldown = 1f;
    public int maxJumps = 2; // Número máximo de saltos permitidos (doble salto)
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;
    public GameObject menu;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isFacingRight = true;
    public float groundCheckRadius = 0.2f;
    private float lastDashTime;
    private int jumpCount; // Contador de saltos
    private float lastEscapePressTime = 0f;   // Momento en que se presionó Escape por última vez
    private float doublePressThreshold = 0.5f; // Tiempo en segundos permitido entre dos presiones (ajustable)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleDash();
        HandleMenu();
        
    }

    // Función para manejar el movimiento y el flip del jugador
    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Cambia la dirección del sprite si es necesario
        if ((moveInput > 0 && !isFacingRight) || (moveInput < 0 && isFacingRight))
        {
            Flip();
        }
    }

    // Función para manejar el salto y el doble salto
    void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Reiniciar el contador de saltos cuando el jugador está en el suelo
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Comprobar si se ha presionado la tecla de salto y si aún quedan saltos disponibles
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++; // Incrementar el contador de saltos
        }
    }

    // Función para manejar el dash
    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown)
        {
            Vector2 dashDirection = isFacingRight ? Vector2.right : Vector2.left;

            // Comprobación de colisión en la dirección del dash
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dashDirection, dashDistance, obstacleLayer);
            float dashRange = hit.collider != null ? hit.distance : dashDistance;

            // Realizar el dash solo hasta el obstáculo o la distancia máxima
            rb.MovePosition(rb.position + dashDirection * dashRange);
            lastDashTime = Time.time;
        }
    }

    // Función para abrir el menú
    void HandleMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu != null)
        {
            // Si el menú está activo, desactívalo
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }
            else
            {
                // Si el menú está inactivo, actívalo y verifica el doble clic
                menu.SetActive(true);

                // Detecta si Escape se ha presionado dos veces para salir
                if (Time.time - lastEscapePressTime < doublePressThreshold)
                {
                    ExitGame();
                }

                // Actualiza el tiempo de la última pulsación de Escape
                lastEscapePressTime = Time.time;
            }
        }
    }

    // Función para voltear el sprite del jugador según la dirección del movimiento
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para el editor de Unity
#else
            Application.Quit(); // Para builds finales
#endif
    }

}
