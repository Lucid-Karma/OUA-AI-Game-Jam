using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float spawnInterval = 2.0f;
    public float spawnHeight = 80f;
    public Vector3 spawnAreaSize = new Vector3(100f, 0, 100f);

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMeteor();
            timer = 0;
        }
    }

    void SpawnMeteor()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            spawnHeight,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
    }
}
