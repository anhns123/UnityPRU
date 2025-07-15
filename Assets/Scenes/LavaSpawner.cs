using System.Collections;
using UnityEngine;

public class LavaSpawner : MonoBehaviour
{
    public GameObject lavaPrefab;          // Prefab lava
    public Transform[] spawnPoints;        // Tất cả điểm spawn

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;

    void Start()
    {
        foreach (Transform point in spawnPoints)
        {
            StartCoroutine(SpawnLavaAtPoint(point));
        }
    }

    IEnumerator SpawnLavaAtPoint(Transform spawnPoint)
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);

            GameObject lava = Instantiate(lavaPrefab, spawnPoint.position, Quaternion.identity);

            // Lava sẽ tự hủy sau vài giây
            Destroy(lava, 3f); // Bạn có thể chỉnh 3f thành 4f, 5f tùy ý
        }
    }
}
