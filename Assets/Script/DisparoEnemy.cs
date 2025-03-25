using UnityEngine;

public class DisperoEnenmy : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform target;             // Objetivo hacia donde se dispara el proyectil
    public float shootingForce = 10f;    // Fuerza con la que se disparará el proyectil
    public float fireRate = 1f;          // Tasa de disparo (segundos entre disparos)
    public float spawnOffset = 0.5f;     // Distancia delante del shooter donde aparece el proyectil

    private float nextFireTime = 0f;     // Controlador para la tasa de disparo

    void Update()
    {
        // Comprobar si ha pasado el tiempo de espera para disparar
        if (Time.time > nextFireTime)
        {
            ShootProjectile();
            nextFireTime = Time.time + fireRate; // Restablece el temporizador
        }
    }

    void ShootProjectile()
    {
        if (projectilePrefab != null && target != null)
        {
            // Calculamos la dirección hacia el objetivo
            Vector2 direction = (target.position - transform.position).normalized;

            // Determinar la posición inicial del proyectil con un pequeño offset en la dirección del disparo
            Vector2 spawnPosition = (Vector2)transform.position + direction * spawnOffset;

            // Crear el proyectil en la nueva posición calculada
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

            // Aplicar la fuerza al proyectil en la dirección del objetivo
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * shootingForce;
            }

            // Desactivar colisiones momentáneamente para evitar autocolisión
            Collider2D projectileCollider = projectile.GetComponent<Collider2D>();
            if (projectileCollider != null)
            {
                Physics2D.IgnoreCollision(projectileCollider, GetComponent<Collider2D>());
                StartCoroutine(EnableCollisionAfterDelay(projectileCollider));
            }
        }
    }

    private System.Collections.IEnumerator EnableCollisionAfterDelay(Collider2D projectileCollider)
    {
        yield return new WaitForSeconds(0.1f); // Pequeño retraso
        projectileCollider.enabled = true;
    }
}
