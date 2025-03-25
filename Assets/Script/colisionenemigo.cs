using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 3; // Vida del enemigo

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisión detectada con: " + other.gameObject.name); // Mensaje para ver qué choca con el enemigo

        if (other.CompareTag("Bala")) // Si la colisión es con una bala
        {
            Debug.Log("El enemigo ha sido impactado por una bala."); // Confirmación en consola
            RecibirDaño(1);
            Destroy(other.gameObject); // Destruir la bala
        }
    }

    void RecibirDaño(int daño)
    {
        vida -= daño;
        Debug.Log("Vida restante del enemigo: " + vida); // Mensaje de prueba

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("El enemigo ha muerto."); // Confirmación en consola
        Destroy(gameObject);
    }
}