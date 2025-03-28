using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public GameObject replacementPrefab; // Prefab del objeto que aparecerá

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BalaPlayer"))
        {
            if (replacementPrefab != null)
            {
                Instantiate(replacementPrefab, transform.position, Quaternion.identity);
            }

            ScoreManager.Instance.AddScore(10); // Llamar al ScoreManager para sumar puntos

            Destroy(gameObject); // Destruye al enemigo
            Destroy(collision.gameObject); // Destruye la bala
        }
    }
}