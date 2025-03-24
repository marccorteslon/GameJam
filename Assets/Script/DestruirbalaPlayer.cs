using UnityEngine;

public class DestruirBalaPlayer : MonoBehaviour
{
    // Método que se llama cuando el objeto entra en colisión con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si el objeto con el que colisionamos no tiene el tag "Player"
        if (collision.gameObject.tag != "Player")
        {
            // Destruir este objeto si no colisiona con un objeto que tenga el tag "Player"
            Destroy(gameObject);
        }
    }
}
