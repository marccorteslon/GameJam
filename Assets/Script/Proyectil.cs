using UnityEngine;
using TMPro; // Asegúrate de incluir esta línea para trabajar con TextMesh Pro

public class Proyectil : MonoBehaviour
{
    public GameObject bala;
    public float velocidadBala = 11f;
    public float tiempoEntreDisparos = 0.5f;
    float balaOffsetX = 0f;
    float balaOffsetY = 0.53f;
    public int powerup = 0;
    public int vidaDisparo = 3;
    private float nextShootTime = 0f;

    // Variable para contar las balas disparadas
    private int contadorBalas = 3; // Contador inicial de balas (para debug, se puede ajustar)
    public int maxBalas = 3; // Máximo de balas que puedes disparar (para debug)

    // Referencia al texto de UI para mostrar el contador de balas usando TextMesh Pro
    public TextMeshProUGUI contadorText;

    private void Update()
    {
        // Verifica si puedes disparar y si aún no has alcanzado el máximo de balas
        if (Input.GetMouseButton(0) && Time.time >= nextShootTime && contadorBalas > 0)
        {
            Shoot();
            nextShootTime = Time.time + tiempoEntreDisparos;
            contadorBalas--; // Reduce el contador de balas después de disparar
            Debug.Log("Balas restantes: " + contadorBalas); // Muestra el contador para depuración
        }

        // Si alcanzas el límite de balas, muestra un mensaje en la consola
        if (contadorBalas <= 0)
        {
            Debug.Log("¡No puedes disparar más, balas agotadas!");
        }

        // Actualiza el texto en la pantalla con el contador de balas usando TextMesh Pro
        if (contadorText != null)
        {
            contadorText.text = "Balas: " + contadorBalas;
        }
    }

    private void Shoot()
    {
        for (int i = -powerup; i <= powerup; i++)
        {
            Vector2 position = (Vector2)transform.position + (Vector2)transform.up * balaOffsetY;
            position += i * balaOffsetX * (Vector2)transform.right;

            GameObject bullet = Instantiate(bala, position, transform.rotation);

            Rigidbody2D bulletRigidbody2D = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody2D.velocity = transform.up * velocidadBala;

            Destroy(bullet, vidaDisparo);
        }
    }

    // Método para recargar las balas, puedes llamarlo cuando quieras (por ejemplo, con un power-up)
    public void RecargarBalas()
    {
        contadorBalas = maxBalas; // Resetea el contador de balas
        Debug.Log("Balas recargadas.");
    }

    // Detecta la colisión con un objeto específico y recarga las balas sumando 10
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Aquí, verificamos si el objeto con el que colisionamos tiene la etiqueta "Recarga"
        if (other.CompareTag("Recarga"))
        {
            contadorBalas += 10; // Suma 10 balas al contador
            Debug.Log("¡Colisión con objeto de recarga! Balas ahora: " + contadorBalas);
            Destroy(other.gameObject); // Destruye el objeto con el que se ha colisionado (por ejemplo, un power-up)
        }
    }
}
