using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foodPrefabs;   // 3 makanan kamu masukkan ke sini
    public float minSpawnDelay = 0.5f; // jeda random
    public float maxSpawnDelay = 1.5f;

    public float fallSpeed = 2f;       // kecepatan jatuh (semakin besar semakin cepat)

    private Camera cam;
    private float minX;
    private float maxX;

    void Start()
    {
        cam = Camera.main;

        // Batas spawn left & right
        Vector2 left = cam.ViewportToWorldPoint(new Vector2(0, 1));
        Vector2 right = cam.ViewportToWorldPoint(new Vector2(1, 1));

        minX = left.x + 0.5f;   // padding biar tidak muncul setengah
        maxX = right.x - 0.5f;

        StartCoroutine(SpawnRoutine());
    }

    System.Collections.IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnFood();
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    void SpawnFood()
    {
        // pilih makanan random
        GameObject prefab = foodPrefabs[Random.Range(0, foodPrefabs.Length)];

        float spawnX = Random.Range(minX, maxX);
        float spawnY = cam.ViewportToWorldPoint(new Vector2(0.5f, 1.1f)).y; // sedikit di atas layar

        GameObject food = Instantiate(prefab, new Vector2(spawnX, spawnY), Quaternion.identity);

        // tambahkan skrip jatuh
        Fallen f = food.AddComponent<Fallen>();
        f.fallSpeed = fallSpeed;
    }
}