using UnityEngine;

public class ApuntarHaciaCursor : MonoBehaviour
{
    void Update()
    {
        // Obtener la posición del cursor en el mundo
        Vector3 posicionCursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calcular la dirección desde el objeto hacia el cursor
        Vector3 direccion = posicionCursor - transform.position;

        // Ajustar la dirección para que esté en el plano 2D (ignorando el eje Z)
        direccion.z = 0;

        // Calcular el ángulo para rotar el objeto hacia el cursor
        float angle = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        // Asegurarse de que el objeto apunte en la dirección correcta
        // Si tu sprite está mirando de frente hacia la derecha (por defecto),
        // entonces no necesitas ajustar más la rotación
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}
