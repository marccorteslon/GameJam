using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al jugador
    public float speed = 2f; // Velocidad de movimiento del enemigo
    private float originalSpeed;

    private void Start()
    {
        originalSpeed = speed; // Guardamos la velocidad original
    }

    private void Update()
    {
        // Comprueba que el jugador está asignado
        if (player != null)
        {
            // Calcula la dirección hacia el jugador
            Vector3 direction = (player.position - transform.position).normalized;

            // Mueve al enemigo hacia el jugador sin necesidad de rotarlo
            transform.position += direction * speed * Time.deltaTime;
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
