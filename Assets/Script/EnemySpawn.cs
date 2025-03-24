using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab; // Prefab único del enemigo
    public Transform player; // Referencia al jugador
    public float spawnRadius = 20f; // Radio en el que aparecerán los enemigos fuera del mapa
    public float initialSpawnInterval = 5f; // Intervalo inicial entre apariciones (en segundos)
    public float minSpawnInterval = 0.5f; // Tiempo mínimo entre spawns (evita que sea demasiado rápido)
    public float accelerationRate = 0.95f; // Factor de reducción del tiempo de spawn
    public Camera mainCamera; // Referencia a la cámara principal
    public float spawnOutsideMargin = 5f; // Margen para asegurar que los enemigos aparecen fuera de la cámara

    private float currentSpawnInterval; // Intervalo actual entre spawns
    private float spawnTimer; // Temporizador para controlar el spawn
    private int currentEnemyCount = 0; // Contador de enemigos activos

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        spawnTimer = currentSpawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f && currentEnemyCount < 5) // Limita el número total de enemigos a 5
        {
            SpawnEnemyGroup();
            spawnTimer = currentSpawnInterval;
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval * accelerationRate);
        }
    }

    private void SpawnEnemyGroup()
    {
        Vector3 spawnPosition = GetSpawnPositionOutsideCamera();

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        currentEnemyCount++; // Aumenta el contador de enemigos activos

        EnemyFollow enemyScript = enemy.GetComponent<EnemyFollow>();
        if (enemyScript != null && player != null)
        {
            enemyScript.player = player; // Asigna el jugador como objetivo
        }
    }

    private Vector3 GetSpawnPositionOutsideCamera()
    {
        Vector3 spawnPosition;
        do
        {
            Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
            spawnPosition = new Vector3(randomPosition.x + player.position.x, randomPosition.y + player.position.y, 0);
        }
        while (IsPositionInCameraView(spawnPosition));

        return spawnPosition;
    }

    private bool IsPositionInCameraView(Vector3 position)
    {
        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(position);
        return viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1;
    }
}
