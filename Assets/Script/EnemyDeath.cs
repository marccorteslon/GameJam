using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BalaPlayer"))
        {
            Destroy(gameObject); // Destruye al enemigo
            //Destroy(collision.gameObject); // Destruye la bala
        }
    }
}
