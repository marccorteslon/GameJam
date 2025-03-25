using UnityEngine;
using System.Collections;

public class ToggleCuchillo : MonoBehaviour
{
    private Renderer cuchilloRenderer;
    private Collider cuchilloCollider;
    private Animator cuchilloAnimator; // Referencia al Animator
    private bool isVisible = false; // El cuchillo empieza invisible
    public float tiempoVisible = 0.5f; // Tiempo que el cuchillo estar� activo

    void Start()
    {
        // Obtener el Renderer, el Collider y el Animator del cuchillo
        cuchilloRenderer = GetComponent<Renderer>();
        cuchilloCollider = GetComponent<Collider>();
        cuchilloAnimator = GetComponent<Animator>();

        if (cuchilloRenderer == null || cuchilloCollider == null || cuchilloAnimator == null)
        {
            Debug.LogError("Falta un Renderer, Collider o Animator en el objeto Cuchillo.");
        }

        // Ocultar el cuchillo al inicio
        SetVisibility(false);
    }

    void Update()
    {
        // Detecta el clic derecho (bot�n secundario del rat�n)
        if (Input.GetMouseButtonDown(1)) // 1 es el bot�n derecho del mouse
        {
            StartCoroutine(ShowCuchilloTemporarily());
        }
    }

    IEnumerator ShowCuchilloTemporarily()
    {
        SetVisibility(true); // Mostrar el cuchillo
        ChangeAnimation(); // Cambiar la animaci�n al pulsar el clic derecho
        yield return new WaitForSeconds(tiempoVisible); // Esperar el tiempo definido
        SetVisibility(false); // Ocultar el cuchillo
    }

    void SetVisibility(bool state)
    {
        if (cuchilloRenderer != null) cuchilloRenderer.enabled = state;
        if (cuchilloCollider != null) cuchilloCollider.enabled = state;
    }

    void ChangeAnimation()
    {
        // Cambiar la animaci�n. Supongamos que tienes una animaci�n llamada "NuevoCuchilloAnim".
        if (cuchilloAnimator != null)
        {
            cuchilloAnimator.Play("AnimCuchillo"); // Reemplaza "NuevoCuchilloAnim" por el nombre de tu animaci�n
        }
    }
}
