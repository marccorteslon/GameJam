using UnityEngine;

public class EscopetaEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform target;             // Objetivo hacia donde se dispara el proyectil
    public float shootingForce = 10f;    // Fuerza del disparo
    public float fireRate = 1f;          // Tasa de disparo (segundos entre disparos)
    public float spawnOffset = 0.5f;     // Distancia delante del enemigo donde aparece el proyectil
    public float spreadAngle = 15f;      // Ángulo de separación entre los dos proyectiles

    private float nextFireTime = 0f;     // Controlador para la tasa de disparo

    void Update()
    {
        // Comprobar si ha pasado el tiempo para disparar
        if (Time.time > nextFireTime)
        {
            ShootProjectiles();
            nextFireTime = Time.time + fireRate; // Restablece el temporizador
        }
    }

    void ShootProjectiles()
    {
        if (projectilePrefab != null && target != null)
        {
            // Dirección base hacia el objetivo
            Vector2 baseDirection = (target.position - transform.position).normalized;

            // Cálculo de los dos ángulos de disparo (izquierda y derecha)
            Quaternion leftRotation = Quaternion.Euler(0, 0, spreadAngle);
            Quaternion rightRotation = Quaternion.Euler(0, 0, -spreadAngle);

            // Direcciones de los dos proyectiles
            Vector2 leftDirection = leftRotation * baseDirection;
            Vector2 rightDirection = rightRotation * baseDirection;

            // Instanciar y disparar los dos proyectiles
            FireProjectile(leftDirection);
            FireProjectile(rightDirection);
        }
    }

    void FireProjectile(Vector2 direction)
    {
        Vector2 spawnPosition = (Vector2)transform.position + direction * spawnOffset;

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

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

    private System.Collections.IEnumerator EnableCollisionAfterDelay(Collider2D projectileCollider)
    {
        yield return new WaitForSeconds(0.1f); // Pequeño retraso
        projectileCollider.enabled = true;
    }
}