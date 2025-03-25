using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject enemyPrefab1; // Prefab del enemigo com�n (90%)
    public GameObject enemyPrefab2; // Prefab del enemigo raro (10%)
    public GameObject enemyPrefab3; // Prefab del enemigo raro (10%)
    public GameObject enemyPrefab4; // Prefab del enemigo raro (10%)

    public Transform player; // Referencia al jugador
    public float spawnRadius = 20f; // Radio en el que aparecer�n los enemigos fuera del mapa
    public float initialSpawnInterval = 15f; // Intervalo inicial entre apariciones (en segundos) (m�s largo)
    public float minSpawnInterval = 3f; // Tiempo m�nimo entre spawns (m�s largo para menos enemigos)
    public float accelerationRate = 0.99f; // Factor de reducci�n del tiempo de spawn (m�s lento)
    public int minGroupSize = 1; // Tama�o m�nimo del grupo de enemigos (1 enemigo por spawn)
    public int maxGroupSize = 2; // Tama�o m�ximo del grupo de enemigos (solo 2 enemigos por spawn)
    public Camera mainCamera; // Referencia a la c�mara principal
    public float spawnOutsideMargin = 5f; // Margen para asegurar que los enemigos aparecen fuera de la c�mara

    private float currentSpawnInterval; // Intervalo actual entre spawns
    private float spawnTimer; // Temporizador para controlar el spawn
    private Vector3[] spawnPattern; // Patr�n de posiciones de spawn predefinido
    private int spawnPatternIndex; // �ndice del patr�n de spawn actual

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        spawnTimer = currentSpawnInterval;

        // Definir un patr�n de spawn con posiciones fijas
        spawnPattern = new Vector3[]
        {
            new Vector3(10, 10, 0),
            new Vector3(-10, 10, 0),
            new Vector3(10, -10, 0),
            new Vector3(-10, -10, 0),
            new Vector3(0, 15, 0),
            new Vector3(0, -15, 0)
        };
        spawnPatternIndex = 0;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnEnemyGroup();
            spawnTimer = currentSpawnInterval;
            currentSpawnInterval = Mathf.Max(minSpawnInterval, currentSpawnInterval * accelerationRate);
        }
    }

    private void SpawnEnemyGroup()
    {
        int groupSize = Random.Range(minGroupSize, maxGroupSize + 1);
        Vector3 spawnPosition = GetNextSpawnPosition();

        for (int i = 0; i < groupSize; i++)
        {
            Vector3 spawnOffset = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
            Vector3 finalSpawnPosition = spawnPosition + spawnOffset;

            float rand = Random.value;

            GameObject enemyPrefab = rand < 0.7f ? enemyPrefab1 :
                                     rand < 0.87f ? enemyPrefab2 :
                                     rand < 0.97f ? enemyPrefab3 : enemyPrefab4; // 70% para enemigo 1, 17% para enemigo 2, 10% para enemigo 3, 3% para enemigo 4
            GameObject enemy = Instantiate(enemyPrefab, finalSpawnPosition, Quaternion.identity);

            EnemyFollow enemyScript = enemy.GetComponent<EnemyFollow>();
            if (enemyScript != null && player != null)
            {
                enemyScript.player = player; // Asigna el jugador como objetivo
            }
        }
    }

    private Vector3 GetNextSpawnPosition()
    {
        // Usar el siguiente punto del patr�n de spawn y luego incrementar el �ndice
        Vector3 spawnPosition = spawnPattern[spawnPatternIndex];
        spawnPatternIndex = (spawnPatternIndex + 1) % spawnPattern.Length; // Asegura que el �ndice nunca se salga del arreglo
        return spawnPosition;
    }
}
