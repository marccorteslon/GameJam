using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform target;             // Objetivo hacia donde se dispara el proyectil
    public float shootingForce = 10f;    // Fuerza con la que se disparará el proyectil
    public float fireRate = 1f;          // Tasa de disparo (segundos entre disparos)

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
            // Crear el proyectil en la posición actual del objeto que dispara
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Calculamos la dirección hacia el objetivo
            Vector2 direction = (target.position - transform.position).normalized;

            // Aplicar la fuerza al proyectil en la dirección del objetivo
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction * shootingForce;
            }
        }
    }
}
