using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoDeVida = 3f; // Tiempo antes de que la bala desaparezca

    void Start()
    {
        gameObject.tag = "Bala"; // Asegura que la bala tenga la etiqueta correcta
        Destroy(gameObject, tiempoDeVida); // Destruir la bala después de un tiempo
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bala impactó con: " + other.gameObject.name); // Ver qué objeto choca con la bala

        if (other.CompareTag("Enemigo"))
        {
            Debug.Log("Bala impactó al enemigo.");
            Destroy(gameObject); // Destruir la bala
        }
    }
}