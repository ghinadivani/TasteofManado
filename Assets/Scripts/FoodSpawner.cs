using UnityEngine;
using System.Collections;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;   // prefab makanan
    public float minSpawnDelay = 0.5f;
    public float maxSpawnDelay = 1.5f;
    public float fallSpeed = 2f;

    // BATAS X DALAM BENTUK GAMEOBJECT (BIAR BISA DI-DRAG DI SCENE)
    public Transform leftLimit;
    public Transform rightLimit;

    private Camera cam;
    private float minX;
    private float maxX;

    void Start()
    {
        cam = Camera.main;

        if (leftLimit == null || rightLimit == null)
        {
            Debug.LogError("LeftLimit / RightLimit belum di-assign di Inspector!");
            return;
        }

        minX = leftLimit.position.x;
        maxX = rightLimit.position.x;

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnFood();
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    void SpawnFood()
    {
        if (foodPrefabs.Length == 0) return;

        float spawnX = Random.Range(minX, maxX);

        // sedikit di atas layar
        float spawnY = cam.ViewportToWorldPoint(new Vector3(0.5f, 1.1f, 0f)).y;

        GameObject prefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];
        GameObject food = Instantiate(prefab, new Vector2(spawnX, spawnY), Quaternion.identity);

        Food foodScript = food.GetComponent<Food>();
        if (foodScript != null)
        {
            foodScript.fallSpeed = fallSpeed;
        }
    }
}