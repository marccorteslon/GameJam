using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int vida = 3; // Vida del enemigo

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colisi�n detectada con: " + other.gameObject.name); // Mensaje para ver qu� choca con el enemigo

        if (other.CompareTag("Bala")) // Si la colisi�n es con una bala
        {
            Debug.Log("El enemigo ha sido impactado por una bala."); // Confirmaci�n en consola
            RecibirDa�o(1);
            Destroy(other.gameObject); // Destruir la bala
        }
    }

    void RecibirDa�o(int da�o)
    {
        vida -= da�o;
        Debug.Log("Vida restante del enemigo: " + vida); // Mensaje de prueba

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("El enemigo ha muerto."); // Confirmaci�n en consola
        Destroy(gameObject);
    }
}