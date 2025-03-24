using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    private float originalSpeed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D
        originalSpeed = speed; // Guarda la velocidad original
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector2 direction = (player.position - transform.position).normalized;

            // Aplica la velocidad usando física
            rb.velocity = direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ralentización
        if (collision.gameObject.layer == LayerMask.NameToLayer("Slowed"))
        {
            speed = originalSpeed * 0.5f; // Reduce la velocidad a la mitad
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Si deja de colisionar con la capa ralentizada, vuelve a la velocidad normal
        if (collision.gameObject.layer == LayerMask.NameToLayer("Slowed"))
        {
            speed = originalSpeed;
        }
    }
}
