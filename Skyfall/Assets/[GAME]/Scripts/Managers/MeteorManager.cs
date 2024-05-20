using UnityEngine;
using UnityEngine.Events;

public class MeteorManager : MonoBehaviour
{
    // Meteor yok edildiðinde tetiklenen bir UnityEvent 
    [HideInInspector] public static UnityEvent OnMeteorDestroy = new UnityEvent();

    // Spawn edilebilecek meteor prefablarý 
    public GameObject[] meteorPrefabs;
    // Meteor spawn etme aralýðý 
    public float spawnInterval = 2.0f;
    // Meteorlarýn spawn yüksekliði 
    public float spawnHeight = 80f;
    // Meteorlarýn spawn olabileceði alanýn boyutlarý 
    public Vector3 spawnAreaSize = new Vector3(100f, 0, 100f);
    private float timer; // Spawn zamanlayýcýsý
    private int _meteorIndex; // Seçilecek meteor prefabýnýn index'i

    private void Start()
    {
        // 10 saniyede bir "DecreaseSpawnInterval" metodu çaðrýlacak þekilde ayarlanýr
        InvokeRepeating("DecreaseSpawnInterval", 10f, 10f);
    }

    void Update()
    {
        // Zamanlayýcýyý oyunun geçen süresiyle güncelle
        timer += Time.deltaTime;

        // Zamanlayýcý spawn aralýðýna eþit veya geçtiyse meteor spawn et
        if (timer >= spawnInterval)
        {
            SpawnMeteor();
            timer = 0; // Zamanlayýcýyý sýfýrla
        }
    }

    void SpawnMeteor()
    {
        // Rastgele bir spawn pozisyonu hesapla
        Vector3 spawnPosition = new Vector3(
          Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
          spawnHeight,
          Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Spawn edilecek meteor prefabýnýn index'ini rastgele seç
        _meteorIndex = Random.Range(0, meteorPrefabs.Length);
        // Seçilen meteor prefabýndan bir örnek oluþtur ve spawn pozisyonuna yerleþtir
        Instantiate(meteorPrefabs[_meteorIndex], spawnPosition, Quaternion.identity);
    }

    void DecreaseSpawnInterval()
    {
        // Spawn aralýðýný zamanla azalt (zorlaþtýr)

        // Spawn aralýðý 0'dan büyükse devam et
        if (spawnInterval > 0)
        {
            if (spawnInterval > 0.5f)
            {
                spawnInterval -= 0.5f;
            }
            else if (spawnInterval == 0.5f)
            {
                spawnInterval = 0.5f;
            }
        }
        else
        {
            spawnInterval = 0.5f;
        }
    }
}
