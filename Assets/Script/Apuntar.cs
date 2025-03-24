using UnityEngine;

public class ApuntarHaciaCursor : MonoBehaviour
{
    void Update()
    {
        // Obtener la posici�n del cursor en el mundo
        Vector3 posicionCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la direcci�n desde el objeto hacia el cursor
        Vector3 direccion = posicionCursor - transform.position;

        // Ajustar la direcci�n para que est� en el plano 2D (ignorando el eje Z)
        direccion.z = 0;

        // Calcular el �ngulo para rotar el objeto hacia el cursor
        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Asegurarse de que el objeto apunte en la direcci�n correcta
        // Si tu sprite est� mirando de frente hacia la derecha (por defecto),
        // entonces no necesitas ajustar m�s la rotaci�n
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
