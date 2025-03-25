using UnityEngine;

public class BalaEnemy : MonoBehaviour
{
    // M�todo que se llama cuando ocurre una colisi�n con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si el objeto con el que colisionamos tiene el tag "Bala"
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            // Destruir el objeto con el que este script est� asociado (el objeto que lleva el script)
            Destroy(gameObject);
        }
    }
}
