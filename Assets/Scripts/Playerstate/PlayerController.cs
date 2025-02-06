using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public Vector2 startPosition;
    public Vector2 vecGravity;

    [SerializeField] float speed = 5f;

    [Header("JumpSystem")]    
    [SerializeField] float jumpTime;
    [SerializeField] float jumpPower;
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpMultiplier;

    public int maxJumps = 2;
    public bool isJumping;
    public float jumpCounter;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    [Header("DashSystem")]
    public float dashDistance = 5f;
    public float dashCooldown = 1f;
        
    
    public LayerMask obstacleLayer;

    public GameObject menu;
    public GameObject Player;
    private Rigidbody2D rb;
    public Animator animator;
    
    private bool isFacingRight = true;

    private float lastDashTime;
    
    

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
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(1.8f, 0.3f ), CapsuleDirection2D.Horizontal, 0, groundLayer);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            jumpCounter = 0;                       
        }
        if (rb.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            rb.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }
        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
        if(rb.velocity.y < 0)
        {
            rb.velocity -= vecGravity * fallMultiplier * Time.deltaTime;
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
