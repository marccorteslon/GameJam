using UnityEngine;
using System.Collections;

public class ToggleCuchillo : MonoBehaviour
{
    private Renderer cuchilloRenderer;
    private Collider cuchilloCollider;
    private bool isVisible = false; // El cuchillo empieza invisible
    public float tiempoVisible = 0.5f; // Tiempo que el cuchillo estar� activo

    void Start()
    {
        // Obtener el Renderer y el Collider del cuchillo
        cuchilloRenderer = GetComponent<Renderer>();
        cuchilloCollider = GetComponent<Collider>();

        if (cuchilloRenderer == null || cuchilloCollider == null)
        {
            Debug.LogError("Falta un Renderer o Collider en el objeto Cuchillo.");
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
        yield return new WaitForSeconds(tiempoVisible); // Esperar el tiempo definido
        SetVisibility(false); // Ocultar el cuchillo
    }

    void SetVisibility(bool state)
    {
        if (cuchilloRenderer != null) cuchilloRenderer.enabled = state;
        if (cuchilloCollider != null) cuchilloCollider.enabled = state;
    }
}