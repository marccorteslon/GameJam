using UnityEngine;

public class NaveDisparoScr : MonoBehaviour
{
    public GameObject bala;
    public float velocidadBala = 11f;
    public float tiempoEntreDisparos = 0.5f;
    float balaOffsetX = 0f;  
    float balaOffsetY = 0.53f;
    public int powerup = 0;
    public int vidaDisparo = 3;
    private float nextShootTime = 0f;

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextShootTime)
        {
            Shoot();
            nextShootTime = Time.time + tiempoEntreDisparos;
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
}