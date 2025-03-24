using UnityEngine;

public class BalaPlayer : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        // Comprobar si el objeto con el que colisiona tiene el tag "BalaPlayer"
        if (col.gameObject.CompareTag("BalaJugador"))
        {
            return; // Ignora la colisi�n
        }

        // Destruir el objeto actual si la colisi�n no es con una bala del jugador
        Destroy(gameObject);
    }
}
