using UnityEngine;

public class WallCollider : MonoBehaviour
{
    void Start()
    {
        if (gameObject.GetComponent<Collider2D>() == null)
        {
            gameObject.AddComponent<BoxCollider2D>(); // Usa el Collider que mejor se adapte
        }
    }
}
