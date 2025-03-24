using UnityEngine;

public class ToggleCuchillo : MonoBehaviour
{
    private Renderer cuchilloRenderer;
    private Collider cuchilloCollider;
    private bool isVisible = false; // El cuchillo empieza invisible

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
        // Detecta el clic derecho (botón secundario del ratón)
        if (Input.GetMouseButtonDown(1)) // 1 es el botón derecho del mouse
        {
            ToggleVisibility();
        }
    }

    void ToggleVisibility()
    {
        isVisible = !isVisible; // Alterna entre visible/invisible
        SetVisibility(isVisible);
    }

    void SetVisibility(bool state)
    {
        if (cuchilloRenderer != null) cuchilloRenderer.enabled = state;
        if (cuchilloCollider != null) cuchilloCollider.enabled = state;
    }
}