using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed = 20f;
    public float dashCooldown = 1.5f;
    public float dashDuration = 0.3f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isDashing = false;
    private float lastDashTime;
    private Animator animator; // Referencia al Animator

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D
        animator = GetComponent<Animator>(); // Obtiene el Animator
    }

    private void Update()
    {
        // Captura la entrada del teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;

        // Flip del personaje
        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        // Verifica si se puede hacer el dash
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown && movement != Vector2.zero)
        {
            StartCoroutine(Dash());
        }

        // Actualiza el Animator con el movimiento
        animator.SetFloat("Speed", movement.magnitude);
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = movement * speed;
        }
    }

    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        animator.SetBool("isDashing", true); // Activa la animación
        rb.velocity = movement * dashSpeed;
        lastDashTime = Time.time;

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        animator.SetBool("isDashing", false); // Desactiva la animación
        rb.velocity = movement * speed; // Restablece la velocidad normal
    }
}
