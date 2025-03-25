using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerdeath : MonoBehaviour
{
    public GameObject deathScreen;
    private void Start()
    {
        deathScreen.SetActive(false); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BalaEnemy"))
        {
            Destroy(gameObject); // Destruye al enemigo
            Destroy(collision.gameObject); // Destruye la bala

            deathScreen.SetActive(true);  
        }
    }
}
