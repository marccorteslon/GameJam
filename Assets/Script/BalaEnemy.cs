using UnityEngine;

public class BalaEnemy : MonoBehaviour
{
    // Método que se llama cuando ocurre una colisión con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene el tag "Bala"
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            // Destruir el objeto con el que este script está asociado (el objeto que lleva el script)
            Destroy(gameObject);
        }
    }
}
