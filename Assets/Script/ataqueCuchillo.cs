using UnityEngine;

public class CuchilloAtaque : MonoBehaviour
{
    private Collider2D cuchilloCollider;
    public int daño = 1; // Puedes ajustar el daño según el sistema de vida del enemigo

    void Start()
    {
        cuchilloCollider = GetComponent<Collider2D>();

        if (cuchilloCollider == null)
        {
            Debug.LogError("No se encontró un Collider2D en el objeto Cuchillo.");
        }

        // Asegurar que el cuchillo empieza desactivado
        SetCuchilloActivo(false);
    }

    // Método para activar/desactivar el cuchillo
    public void SetCuchilloActivo(bool estado)
    {
        gameObject.SetActive(estado);
    }

    // Detecta colisiones con los enemigos
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo") && gameObject.activeSelf)
        {
            Destroy(other.gameObject); // Destruye al enemigo
            Debug.Log("Enemigo eliminado con el cuchillo.");
        }
    }
}