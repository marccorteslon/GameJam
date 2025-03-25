using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            Destroy(gameObject); // Destruye al enemigo
            Destroy(collision.gameObject); // Destruye la bala
        }
    }
}
