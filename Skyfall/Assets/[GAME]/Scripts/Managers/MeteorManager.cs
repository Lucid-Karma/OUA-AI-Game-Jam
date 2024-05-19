using UnityEngine;
using UnityEngine.Events;

public class MeteorManager : MonoBehaviour
{
    [HideInInspector] public static UnityEvent OnMeteorDestroy = new();

    public GameObject[] meteorPrefabs;
    public float spawnInterval = 2.0f;
    public float spawnHeight = 80f;
    public Vector3 spawnAreaSize = new Vector3(100f, 0, 100f);

    private float timer;
    private int _meteorIndex;

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

        _meteorIndex = Random.Range(0, meteorPrefabs.Length);
        Instantiate(meteorPrefabs[_meteorIndex], spawnPosition, Quaternion.identity);
    }
}
