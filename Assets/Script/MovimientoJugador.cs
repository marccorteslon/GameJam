using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtiene el Rigidbody2D
    }

    private void Update()
    {
        // Captura la entrada del teclado
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector2(horizontal, vertical).normalized;

        // Flip del personaje
        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    private void FixedUpdate()
    {
        // Aplicamos el movimiento usando la física
        rb.velocity = movement * speed;
    }
}
