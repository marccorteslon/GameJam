using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed = 20f;
    public float dashCooldown = 1.5f;
    public float dashDuration = 0.3f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isDashing = false;
    private float lastDashTime;

    [SerializeField] private GameObject normalSpriteObj; // Asignado en el Inspector
    [SerializeField] private GameObject dashSpriteObj;   // Asignado en el Inspector

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Asegura que ambos objetos estén asignados correctamente
        if (normalSpriteObj == null || dashSpriteObj == null)
        {
            Debug.LogError("Los GameObjects no están correctamente asignados en el Inspector.");
        }
        else
        {
            Debug.Log("GameObjects asignados correctamente.");
        }

        // Asegura que el sprite normal esté visible y el de dash no
        normalSpriteObj.SetActive(true);
        dashSpriteObj.SetActive(false);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement = new Vector2(horizontal, vertical).normalized;

        if (horizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastDashTime + dashCooldown && movement != Vector2.zero)
        {
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.velocity = movement * speed;
        }
    }

    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = movement * dashSpeed;
        lastDashTime = Time.time;

        // Depuración: Verifica si se están llamando los cambios de visibilidad
        Debug.Log("Iniciando Dash. Sprite normal invisible, sprite de dash visible.");
        normalSpriteObj.SetActive(false);
        dashSpriteObj.SetActive(true);

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        rb.velocity = movement * speed;

        // Depuración: Verifica si se restauran los sprites
        Debug.Log("Terminando Dash. Sprite normal visible, sprite de dash invisible.");
        normalSpriteObj.SetActive(true);
        dashSpriteObj.SetActive(false);
    }
}
