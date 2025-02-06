using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed = 5f;
    public float jumpForce = 10f;
    public float dashDistance = 5f;
    public float dashCooldown = 1f;
    public int maxJumps = 2; // N�mero m�ximo de saltos permitidos (doble salto)
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask obstacleLayer;
    public GameObject menu;
    public GameObject Player;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isFacingRight = true;
    public float groundCheckRadius = 0.2f;
    private float lastDashTime;
    private int jumpCount; // Contador de saltos
    public Vector2 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        Player.SetActive(false);
        menu.SetActive(true);
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleDash();
        HandleMenu();
        
    }

    // Funci�n para manejar el movimiento y el flip del jugador
    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Cambia la direcci�n del sprite si es necesario
        if ((moveInput > 0 && !isFacingRight) || (moveInput < 0 && isFacingRight))
        {
            Flip();
        }
    }

    // Funci�n para manejar el salto y el doble salto
    void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        //test
        // Reiniciar el contador de saltos cuando el jugador est� en el suelo
        if (isGrounded)
        {
            jumpCount = 0;
        }

        // Comprobar si se ha presionado la tecla de salto y si a�n quedan saltos disponibles
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++; // Incrementar el contador de saltos
        }
    }

    // Funci�n para manejar el dash
    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > lastDashTime + dashCooldown)
        {
            Vector2 dashDirection = isFacingRight ? Vector2.right : Vector2.left;

            // Comprobaci�n de colisi�n en la direcci�n del dash
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dashDirection, dashDistance, obstacleLayer);
            float dashRange = hit.collider != null ? hit.distance : dashDistance;

            // Realizar el dash solo hasta el obst�culo o la distancia m�xima
            rb.MovePosition(rb.position + dashDirection * dashRange);
            lastDashTime = Time.time;
        }
    }

    // Funci�n para abrir el men�
    void HandleMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu != null)
        {
            // Si el men� est� activo, desact�valo
            if (menu.activeSelf)
            {
                menu.SetActive(false);
                Player.SetActive(true);
            }
            else
            {
                
                menu.SetActive(true);
                Player.SetActive(false);
            }
        }
    }

    // Funci�n para voltear el sprite del jugador seg�n la direcci�n del movimiento
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto con el que chocamos tiene el tag "Pinchos"
        if (collision.gameObject.CompareTag("Pinchos"))
        {
            // Si es as�, volvemos a la posici�n inicial
            transform.position = startPosition;
            Debug.Log("Jugador colision� con Pinchos y volvi� a la posici�n inicial.");
        }
    }

}
